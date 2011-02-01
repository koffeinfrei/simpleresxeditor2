using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmMain : BaseForm
    {
        private readonly int BACK_ALT = 15;
        private readonly string PATH_FLAGS = Path.Combine(Application.StartupPath, "Flags");
        private readonly string PATH_SKINS = Path.Combine(Application.StartupPath, "Skins");
        private bool initialChanges = false;
        private bool unsavedChanges = false;
        private Dictionary<int, ContextMenuStrip> contextMenus = new Dictionary<int, ContextMenuStrip>();
        private WordDocument wordDocument;

        public FrmMain()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                loadResxFiles(args);
#if (!DEBUG)
            checkNewVersion();
#else
            MessageBox.Show("This is a debug build", "Debug Build", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
        }

        private void loadSkin()
        {
            //Bitmap bmp;

            //// Load default skin
            //imgListMain.Images.AddStrip(Properties.Resources.toolbar);

            //// User-defined skin
            //string skinFilename = Path.Combine(Application.StartupPath, "toolbar.png");

            //if (File.Exists(skinFilename))
            //{
            //    bmp = new Bitmap(skinFilename);
            //    // Check if it is a valid skin file
            //    if (bmp.Height == SKIN_HEIGHT && bmp.Width == SKIN_WIDTH)
            //    {
            //        // Use user-defined skin
            //        imgListMain.Images.Clear();
            //        imgListMain.Images.AddStrip(bmp);
            //    }
            //}

            tspMain.ImageList = imgListMain;
            tsbtnOpen.Image = Properties.Resources.tsbtnOpen;
            tsbtnSave.Image = Properties.Resources.tsbtnSave;
            tsbtnKeys.Image = Properties.Resources.tsbtnKeys;
            tsbtnFText.Image = Properties.Resources.tsbtnFText;
            tsbtnFAll.Image = Properties.Resources.tsbtnFAll;
            tsbtnHText.Image = Properties.Resources.tsbtnHText;
            tsbtnHDiffs.Image = Properties.Resources.tsbtnHDiffs;
            tsbtnHEquals.Image = Properties.Resources.tsbtnHEquals;
            tsbtnClear.Image = Properties.Resources.tsbtnClear;
            tsbtnSettings.Image = Properties.Resources.tsbtnSettings;
            tsbtnAbout.Image = Properties.Resources.tsbtnAbout;
            tsbtnTranslator.Image = Properties.Resources.tsbtnTranslator;
            tsbtnExport.Image = Properties.Resources.tsbtnExport;
            tsbtnImport.Image = Properties.Resources.tsbtnImport;

            //tsbtnOpen.ImageScaling      = ToolStripItemImageScaling.SizeToFit;
            //tsbtnSave.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnKeys.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnFText.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnFAll.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnHText.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnHDiffs.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnHEquals.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnClear.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnSettings.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            //tsbtnAbout.ImageScaling = ToolStripItemImageScaling.SizeToFit;
        }

        private void loadResxFiles(string[] filenames)
        {
            saveResxFiles(true);
            initialChanges = true;

            int numFiles = filenames.Length;
            int numValidFiles = 0;

            dataGridView.SuspendLayout();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            ArrayList resxFilenames = new ArrayList();

            for (int i = 0; i < numFiles; i++)
            {
                if (filenames[i].EndsWith(".resx", StringComparison.InvariantCultureIgnoreCase))
                {
                    resxFilenames.Add(filenames[i]);
                    numValidFiles++;
                }
            }

            foreach (string file in resxFilenames)
            {
                if (dataGridView.ColumnCount == 0)
                {
                    dataGridView.Columns.Add("keys", "Keys");
                    dataGridView.Columns["keys"].Visible = SettingsHandler.Instance.ShowKeyColumnOnStart;
                    dataGridView.Columns["keys"].DefaultCellStyle.BackColor = Color.FromArgb(SettingsHandler.Instance.Color4);
                    dataGridView.Columns["keys"].Tag = "Keys";
                }

                int newColIndex = dataGridView.Columns.Add(file, Path.GetFileName(file));

                using (ResXResourceReader resxReader = new ResXResourceReader(file))
                {
                    resxReader.UseResXDataNodes = true;
                    IEnumerator enumerator = resxReader.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DictionaryEntry dicEntry = (DictionaryEntry)enumerator.Current;
                        ResXDataNode dataNode = (ResXDataNode)dicEntry.Value;
                        string dataNodeName = dataNode.Name.Trim();
                        int rowIndex = -1;
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            if (dataGridView.Rows[row].Cells["keys"].Value as string == dataNodeName)
                            {
                                rowIndex = row;
                                break;
                            }
                        }
                        if (rowIndex == -1)
                        {
                            rowIndex = dataGridView.Rows.Add();
                            dataGridView.Rows[rowIndex].Cells["keys"].Value = dataNodeName;
                        }

                        if (dataNode.FileRef != null)
                        {
                            dataGridView.Rows[rowIndex].Cells[newColIndex].Style = new DataGridViewCellStyle() { BackColor = Color.Red };
                            dataGridView.Rows[rowIndex].Cells[newColIndex].Value = null;
                            dataGridView.Rows[rowIndex].Cells[newColIndex].Tag = dataNode;
                            dataGridView.Rows[rowIndex].Cells[newColIndex].ReadOnly = true;
                        }
                        else
                        {
                            dataGridView.Rows[rowIndex].Cells[newColIndex].Value = dataNode.GetValue(new AssemblyName[] { });
                            dataGridView.Rows[rowIndex].Cells[newColIndex].Tag = dataNode;
                        }
                    }
                }
                dataGridView.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDown);
            }

            generateContextMenu();

            dataGridView.ResumeLayout();
            initialChanges = false;

            dataGridView.ClearSelection();
        }

        private void generateContextMenu()
        {
            contextMenus.Clear();

            // Create context menus for each column, empty right now, they'll be filled when we know what columns we have
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                var menuStrip = new ContextMenuStrip();
                menuStrip.Opening += new CancelEventHandler(menuStrip_Opening);
                
                contextMenus.Add(column.Index, menuStrip);
                
                column.ContextMenuStrip = contextMenus[column.Index];
                if (column.Name.ToLower() == "keys")
                    column.Tag = "keys";
                else
                    column.Tag = GetLanguageFromFileName(column.Name) ?? "en"; //TODO: configurable default language?
            }

            //Create context menus, one per column
            foreach (var contextMenu in contextMenus)
            {
                foreach (var rawColumn in dataGridView.Columns)
                {
                    var column = rawColumn as DataGridViewColumn;
                    if (column.Index != contextMenu.Key)
                    {
                        var language = column.Tag;
                        if (language == "keys")
                            contextMenu.Value.Items.Add(string.Format(LangHandler.GetString("txtTranslateFrom"), LangHandler.GetString("txtKeys")), null, AutoTranslationClick).Tag = column.Index;
                        else
                            contextMenu.Value.Items.Add(string.Format(LangHandler.GetString("txtTranslateFrom"), language), null, AutoTranslationClick).Tag = column.Index;
                    }
                }
            }
        }

        // Make sure the context menu is not displayed for the keys column
        // or the last row (because it is always empty)
        void menuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0 && (dataGridView.SelectedCells[0].ColumnIndex == 0 || dataGridView.SelectedCells[0].RowIndex == dataGridView.Rows.Count - 1))
                e.Cancel = true;
        }

        // Makes sure the cell under the context menu is selected
        void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                //txtComment_Leave(null, EventArgs.Empty);
                //txtValue_Leave(null, EventArgs.Empty);
                dataGridView.ClearSelection();
                dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                dataGridView_CellEnter(sender, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));
            }
        }

        // Translate
        private void AutoTranslationClick(object sender, EventArgs e)
        {
            var item = (ToolStripItem)sender;
            var cell = dataGridView.SelectedCells[0];

            var fromColumn = (int)item.Tag;
            var sourceCell = dataGridView.Rows[cell.RowIndex].Cells[fromColumn];

            var cellvalue = (string)sourceCell.Value;
            if (string.IsNullOrEmpty(cellvalue))
            {
                MessageBox.Show(LangHandler.GetString("errorEmptySource_msg"), LangHandler.GetString("errorEmptySource_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fromLanguage = dataGridView.Columns[sourceCell.ColumnIndex].Tag as string;
            if (fromLanguage.ToLower() == "keys")
                fromLanguage = "en"; //TODO: configurable default language?
            var toLanguage = dataGridView.Columns[cell.ColumnIndex].Tag as string;

            var translation = Translator.Translate(fromLanguage, toLanguage, cellvalue);
            txtValue.Text = translation;
            txtValue.Focus();
        }

        private string GetLanguageFromFileName(string filename)
        {
            var langName = filename.ToLower().Replace(".resx", "");
            var indexLastDot = langName.LastIndexOf('.');
            if (indexLastDot != -1)
            {
                try
                {
                    langName = langName.Substring(++indexLastDot);
                    var culture = new CultureInfo(langName);
                    return culture.TwoLetterISOLanguageName;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        private void loadLanguageStrings()
        {
            Text = Global.GetNameWithVersion();
            tsbtnOpen.Text = LangHandler.GetString("tsbtnOpen");
            tsbtnOpen.ToolTipText = LangHandler.GetString("tsbtnOpen");
            tsbtnSave.Text = LangHandler.GetString("tsbtnSave");
            tsbtnSave.ToolTipText = LangHandler.GetString("tsbtnSave");
            tsbtnKeys.Text = LangHandler.GetString("tsbtnKeys");
            tsbtnKeys.ToolTipText = LangHandler.GetString("tsbtnKeys");
            tsbtnFText.Text = LangHandler.GetString("tsbtnFText");
            tsbtnFText.ToolTipText = LangHandler.GetString("tsbtnFText");
            tsbtnFAll.Text = LangHandler.GetString("tsbtnFAll");
            tsbtnFAll.ToolTipText = LangHandler.GetString("tsbtnFAll");
            tsbtnHDiffs.Text = LangHandler.GetString("tsbtnHDiffs");
            tsbtnHDiffs.ToolTipText = LangHandler.GetString("tsbtnHDiffs");
            tsbtnHEquals.Text = LangHandler.GetString("tsbtnHEquals");
            tsbtnHEquals.ToolTipText = LangHandler.GetString("tsbtnHEquals");
            tsbtnHText.Text = LangHandler.GetString("tsbtnHText");
            tsbtnHText.ToolTipText = LangHandler.GetString("tsbtnHText");
            tsbtnClear.Text = LangHandler.GetString("tsbtnClear");
            tsbtnClear.ToolTipText = LangHandler.GetString("tsbtnClear");
            tsbtnImport.Text = LangHandler.GetString("tsbtnImport");
            tsbtnImport.ToolTipText = LangHandler.GetString("tsbtnImport");
            tsbtnExport.Text = LangHandler.GetString("tsbtnExport");
            tsbtnExport.ToolTipText = LangHandler.GetString("tsbtnExport");
            tsbtnTranslator.Text = LangHandler.GetString("tsbtnTranslator");
            tsbtnTranslator.ToolTipText = LangHandler.GetString("tsbtnTranslator");
            tsbtnSettings.Text = LangHandler.GetString("tsbtnSettings");
            tsbtnSettings.ToolTipText = LangHandler.GetString("tsbtnSettings");
            tsbtnAbout.Text = LangHandler.GetString("tsbtnAbout");
            tsbtnAbout.ToolTipText = LangHandler.GetString("tsbtnAbout");
            gbComment.Text = LangHandler.GetString("gbComment");
            gbValue.Text = LangHandler.GetString("gbValue");
            generateContextMenu();
        }

        private void checkNewVersion()
        {
            Thread thread = new Thread(Updater.CheckForUpdates);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();
        }

        private void checkDiffs(bool reportEquals, Color colorDiff, Color colorEqual)
        {
            int numDiffs = 0;
            int numColumns = dataGridView.Columns.Count;
            int numRows = dataGridView.Rows.Count - 1;

            if (numColumns > 2)
            {
                dataGridView.SuspendLayout();

                for (int row = 0; row < numRows; row++)
                {
                    int baseColumn;

                    if (dataGridView.SelectedCells.Count > 0)
                    {
                        baseColumn = dataGridView.SelectedCells[0].ColumnIndex;

                        if (baseColumn == 0)
                            baseColumn = 1;
                    }
                    else
                    {
                        baseColumn = 1;
                    }

                    for (int column = 1; column < numColumns; column++)
                    {
                        if (column == baseColumn)
                            continue;

                        if (dataGridView.Rows[row].Cells[baseColumn].Value != null)
                        {
                            if (dataGridView.Rows[row].Cells[baseColumn].Value.Equals(dataGridView.Rows[row].Cells[column].Value))
                            {
                                dataGridView.Rows[row].Cells[column].Style.BackColor = colorEqual;
                            }
                            else
                            {
                                dataGridView.Rows[row].Cells[column].Style.BackColor = colorDiff;
                                numDiffs++;
                            }
                        }
                    }
                }

                dataGridView.ResumeLayout();

                if (reportEquals)
                    tsslStatus.Text = string.Format(LangHandler.GetString("statusHEquals"), numColumns * numRows - numDiffs);
                else
                    tsslStatus.Text = string.Format(LangHandler.GetString("statusHDiffs"), numDiffs);
            }
        }

        private void openResxFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "resx",
                Filter = string.Format("{0}|*.resx", LangHandler.GetString("txtOpen1")),
                Multiselect = true,
                Title = LangHandler.GetString("txtOpen2")
            };

            if (DialogResult.OK == openFileDialog.ShowDialog())
                loadResxFiles(openFileDialog.FileNames);
        }

        private void saveResxFiles(bool askUnsaved)
        {
            try
            {
                if (askUnsaved)
                {
                    if (!unsavedChanges)
                        return;

                    if (DialogResult.No == MessageBox.Show(this, LangHandler.GetString("txtSave1"), LangHandler.GetString("txtSave2"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return;
                }

                txtComment_Leave(null, EventArgs.Empty);
                txtValue_Leave(null, EventArgs.Empty);

                if (SettingsHandler.Instance.SortByKeyOnSave && dataGridView.Columns.Contains("keys"))
                    dataGridView.Sort(dataGridView.Columns["keys"], ListSortDirection.Ascending);

                for (int column = 1; column < dataGridView.Columns.Count; column++)
                {
                    using (ResXResourceWriter resourceWriter = new ResXResourceWriter(dataGridView.Columns[column].Name))
                    {
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            ResXDataNode currentNode = dataGridView.Rows[row].Cells[column].Tag as ResXDataNode;
                            Object currentValue = dataGridView.Rows[row].Cells[column].Value as Object;
                            bool isReadOnly = dataGridView.Rows[row].Cells[column].ReadOnly;

                            if (currentValue != null && !isReadOnly)
                            {
                                ResXDataNode nodeToAdd = new ResXDataNode((string)dataGridView.Rows[row].Cells["keys"].Value, currentValue);
                                if (currentNode != null) nodeToAdd.Comment = currentNode.Comment;
                                resourceWriter.AddResource(nodeToAdd);
                                continue;
                            }

                            if (currentNode != null && isReadOnly)
                            {
                                resourceWriter.AddResource(currentNode);
                            }
                        }

                        resourceWriter.Generate();
                        resourceWriter.Close();
                    }
                }

                unsavedChanges = false;
                resetColors();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(this, string.Format("{0}\n\n{1}", ex.Message, ex.StackTrace), LangHandler.GetString("errorSaving"), MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(this, ex.Message, LangHandler.GetString("errorSaving"), MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void showSettings()
        {
            FrmSettings frmSettings = new FrmSettings();

            if (SettingsHandler.Instance.PrefWindowPosition.IsEmpty)
            {
                frmSettings.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
            else
            {
                frmSettings.StartPosition = FormStartPosition.Manual;
                frmSettings.Location = SettingsHandler.Instance.PrefWindowPosition;
            }

            frmSettings.Size = SettingsHandler.Instance.PrefWindowSize;
            frmSettings.WindowState = SettingsHandler.Instance.PrefWindowState;

            frmSettings.ShowDialog();
        }

        private void resetColors()
        {
            dataGridView.SuspendLayout();
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Empty;
                dataGridView.Rows[row].Cells["keys"].Style.BackColor = Color.FromArgb(SettingsHandler.Instance.Color4);
                for (int column = 1; column < dataGridView.Columns.Count; column++)
                {
                    dataGridView.Rows[row].Cells[column].Style.BackColor = Color.Empty;
                }
            }
            dataGridView.ResumeLayout();
        }

        #region DataGridView

        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            loadResxFiles(files);
            this.Activate();
            this.dataGridView.ClearSelection();
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!initialChanges)
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(SettingsHandler.Instance.Color3);
                unsavedChanges = true;
            }
        }

        private void dataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string cellValue1 = string.Empty;
            string cellValue2 = string.Empty;

            if (e.CellValue1 != null)
                cellValue1 = e.CellValue1.ToString();

            if (e.CellValue2 != null)
                cellValue2 = e.CellValue2.ToString();

            e.SortResult = string.Compare(cellValue1, cellValue2);
            e.Handled = true;
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView[e.ColumnIndex, e.RowIndex];
            bool enabled = !cell.ReadOnly && !(e.RowIndex == dataGridView.Rows.Count - 1);

            txtComment.Enabled = enabled;
            txtValue.Enabled = enabled;

            if (!enabled)
            {
                txtComment.Text = txtValue.Text = null;
            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    txtComment.Enabled = false;
                    txtComment.Text = null;
                }
                else
                {
                    ResXDataNode node = cell.Tag as ResXDataNode;
                    txtComment.Enabled = true;
                    txtComment.Text = (node != null ? node.Comment : null);
                }

                txtValue.Text = (cell.Value != null ? cell.Value.ToString() : null);
            }
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (e.Value == null)
                    return;
                var langName = e.Value.ToString().ToLower().Replace(".resx", "");
                var indexLastDot = langName.LastIndexOf('.');
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                if (indexLastDot != -1)
                {
                    try
                    {
                        langName = langName.Substring(++indexLastDot);
                        CultureInfo culture = new CultureInfo(langName);
                        RegionInfo region = new RegionInfo(culture.TextInfo.LCID);
                        Image flag = Image.FromFile(Path.Combine(PATH_FLAGS, string.Format("{0}.png", region.TwoLetterISORegionName)));
                        Rectangle flagRect = new Rectangle(e.CellBounds.Location, flag.Size);
                        flagRect.Offset(4, 10);
                        e.Graphics.DrawImage(flag, flagRect);
                    }
                    catch (Exception)
                    {
                    }
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            else
            {
                if (e.RowIndex % 2 == 0)
                {
                    //int R = e.CellStyle.BackColor.R + BACK_ALT > 255 ? e.CellStyle.BackColor.R - BACK_ALT : e.CellStyle.BackColor.R + BACK_ALT;
                    //int G = e.CellStyle.BackColor.G + BACK_ALT > 255 ? e.CellStyle.BackColor.G - BACK_ALT : e.CellStyle.BackColor.G + BACK_ALT;
                    //int B = e.CellStyle.BackColor.B + BACK_ALT > 255 ? e.CellStyle.BackColor.B - BACK_ALT : e.CellStyle.BackColor.B + BACK_ALT;
                    int R = e.CellStyle.BackColor.R - BACK_ALT < 0 ? e.CellStyle.BackColor.R : e.CellStyle.BackColor.R - BACK_ALT;
                    int G = e.CellStyle.BackColor.G - BACK_ALT < 0 ? e.CellStyle.BackColor.G : e.CellStyle.BackColor.G - BACK_ALT;
                    int B = e.CellStyle.BackColor.B - BACK_ALT < 0 ? e.CellStyle.BackColor.B : e.CellStyle.BackColor.B - BACK_ALT;
                    e.CellStyle.BackColor = Color.FromArgb(e.CellStyle.BackColor.A, R, G, B);
                }
            }
        }

        #endregion

        #region Events

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadSkin();
            loadLanguageStrings();
            splitContainer1.SplitterDistance = SettingsHandler.Instance.SplitterH;
            splitContainer2.SplitterDistance = SettingsHandler.Instance.SplitterV;
            SettingsHandler.Instance.SettingsChanged += new EventHandler(Settings_SettingsChanged);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveResxFiles(true);
            SettingsHandler.Instance.MainWindowState = WindowState;
            SettingsHandler.Instance.SplitterH = splitContainer1.SplitterDistance;
            SettingsHandler.Instance.SplitterV = splitContainer2.SplitterDistance;
        }

        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {
            SettingsHandler.Instance.MainWindowSize = Size;
        }

        private void FrmMain_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                SettingsHandler.Instance.MainWindowPosition = Location;
        }

        private void Settings_SettingsChanged(object sender, EventArgs e)
        {
            loadLanguageStrings();
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            openResxFiles();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            saveResxFiles(false);
        }

        private void tsbtnKeys_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Contains("keys"))
                dataGridView.Columns["keys"].Visible = !dataGridView.Columns["keys"].Visible;
        }

        private void tsbtnFText_Click(object sender, EventArgs e)
        {
            int numRows = dataGridView.Rows.Count - 1;
            int numColumns = dataGridView.Columns.Count;
            int numTextRows = 0;

            if (numColumns > 0)
            {
                dataGridView.SuspendLayout();
                for (int row = 0; row < numRows; row++)
                {
                    if (dataGridView.Rows[row].Cells["keys"].Value.ToString().EndsWith(".Text") ||
                        dataGridView.Rows[row].Cells["keys"].Value.ToString().EndsWith(".ToolTipText"))
                    {
                        dataGridView.Rows[row].Visible = true;
                        numTextRows++;
                    }
                    else
                    {
                        dataGridView.Rows[row].Visible = false;
                    }
                }
                dataGridView.ResumeLayout();

                tsslStatus.Text = string.Format(LangHandler.GetString("statusFText"), numTextRows, numRows);
            }
        }

        private void tsbtnFAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.Visible = true;
            tsslStatus.Text = string.Format(LangHandler.GetString("statusFAll"), dataGridView.Rows.Count - 1);
        }

        private void tsbtnHDiffs_Click(object sender, EventArgs e)
        {
            checkDiffs(false, Color.FromArgb(SettingsHandler.Instance.Color1), Color.Empty);
        }

        private void tsbtnHEquals_Click(object sender, EventArgs e)
        {
            checkDiffs(true, Color.Empty, Color.FromArgb(SettingsHandler.Instance.Color2));
        }

        private void tsbtnHText_Click(object sender, EventArgs e)
        {
            int numRows = dataGridView.Rows.Count - 1;
            int numColumns = dataGridView.Columns.Count;
            int numTextCells = 0;

            if (numColumns > 0)
            {
                dataGridView.SuspendLayout();
                for (int row = 0; row < numRows; row++)
                {
                    if (dataGridView.Rows[row].Cells["keys"].Value.ToString().EndsWith(".Text") ||
                        dataGridView.Rows[row].Cells["keys"].Value.ToString().EndsWith(".ToolTipText"))
                    {
                        dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(SettingsHandler.Instance.Color5);
                        numTextCells++;
                    }
                    else
                    {
                        dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Empty;
                    }
                }
                dataGridView.ResumeLayout();

                tsslStatus.Text = string.Format(LangHandler.GetString("statusHText"), numTextCells);
            }
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            resetColors();
            tsslStatus.Text = LangHandler.GetString("statusClear");
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            showSettings();
        }

        private void tsbtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
                return;

            var selectedCell = dataGridView.SelectedCells[0];

            if (selectedCell == null)
                return;

            if (selectedCell.Value == null && string.IsNullOrEmpty(txtValue.Text))
                return;

            selectedCell.Value = txtValue.Text;
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //    return; // No se escribio ningún comentario

            if (dataGridView.SelectedCells.Count == 0)
                return; // No hay nada seleccionado

            var selectedCell = dataGridView.SelectedCells[0];

            if (selectedCell == null)
                return;

            if (dataGridView[0, selectedCell.RowIndex].Value == null)
                return;
             
            if (selectedCell.Tag == null)
                selectedCell.Tag = new ResXDataNode(dataGridView[0, selectedCell.RowIndex].Value.ToString(), string.Empty);

            if (selectedCell.Tag.GetType() == typeof(ResXDataNode))
                ((ResXDataNode)selectedCell.Tag).Comment = txtComment.Text;
        }

        #endregion

        private void tsbtnTranslator_Click(object sender, EventArgs e)
        {
            FrmTranslator frmTranslator = new FrmTranslator();

            if (SettingsHandler.Instance.TranWindowPosition.IsEmpty)
            {
                frmTranslator.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
            else
            {
                frmTranslator.StartPosition = FormStartPosition.Manual;
                frmTranslator.Location = SettingsHandler.Instance.TranWindowPosition;
            }

            frmTranslator.Size = SettingsHandler.Instance.TranWindowSize;
            frmTranslator.Show();
        }

        private FrmFind frmFind = null;
        private FindOptions findOptions = null;
        private int currentCell_Col = 0;
        private int currentCell_Row = 0;
        private bool endReached = false;
        private bool beginningReached = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F3:
                    if (findOptions == null)
                        openFindForm(false);
                    else
                        findText(findOptions);
                    return true;
                case Keys.Control | Keys.F:
                    openFindForm(false);
                    return true;
                case Keys.Control | Keys.H:
                    openFindForm(true);
                    return true;
                case Keys.Control | Keys.O:
                    openResxFiles();
                    return true;
                case Keys.Control | Keys.P:
                    showSettings();
                    return true;
            }

            return false;
        }

        private void openFindForm(bool enableReplace)
        {
            if (frmFind == null || frmFind.IsDisposed)
            {
                frmFind = new FrmFind(findOptions);
                frmFind.FindText += new EventHandler(frmFind_FindText);

                if (SettingsHandler.Instance.FindWindowPosition.IsEmpty)
                    frmFind.StartPosition = FormStartPosition.WindowsDefaultLocation;
                else
                {
                    frmFind.StartPosition = FormStartPosition.Manual;
                    frmFind.Location = SettingsHandler.Instance.FindWindowPosition;
                }

                frmFind.Size = SettingsHandler.Instance.FindWindowSize;
                frmFind.Show();
            }

            if (enableReplace)
                frmFind.EnableReplace();
            else
                frmFind.DisableReplace();

            frmFind.Activate();
        }

        private void moveToPrevCell()
        {
            int lastRowIndex = dataGridView.Rows.Count - 2;
            int lastColIndex = dataGridView.Columns.Count - 1;
            beginningReached = false;
            currentCell_Row--;

            if (currentCell_Row < 0)
            {
                currentCell_Row = lastRowIndex;
                currentCell_Col--;

                if (currentCell_Col < 0)
                {
                    beginningReached = true;
                    currentCell_Row = lastRowIndex;
                    currentCell_Col = lastColIndex;
                    MessageBox.Show(LangHandler.GetString("strBegReached_msg"), LangHandler.GetString("strBegReached_title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void moveToNextCell()
        {
            int lastRowIndex = dataGridView.Rows.Count - 2;
            int lastColIndex = dataGridView.Columns.Count - 1;
            endReached = false;
            currentCell_Row++;

            if (currentCell_Row > lastRowIndex)
            {
                currentCell_Row = 0;
                currentCell_Col++;

                if (currentCell_Col > lastColIndex)
                {
                    endReached = true;
                    currentCell_Row = 0;
                    currentCell_Col = 0;
                    MessageBox.Show(LangHandler.GetString("strEndReached_msg"), LangHandler.GetString("strEndReached_title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void setStartCell()
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                currentCell_Row = dataGridView.SelectedCells[0].RowIndex;
                currentCell_Col = dataGridView.SelectedCells[0].ColumnIndex;
            }
            else
            {
                currentCell_Row = 0;
                currentCell_Col = 0;
            }
        }

        private void findText(FindOptions options)
        {
            bool found = false;

            do
            {
                DataGridViewCell currentCell = dataGridView[currentCell_Col, currentCell_Row];
                if (currentCell.Value != null && currentCell.Visible && Contains(currentCell.Value.ToString(), findOptions.TextToFind, findOptions.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
                {
                    currentCell.Style.BackColor = Color.BurlyWood;
                    dataGridView.CurrentCell = currentCell;
                    found = true;
                }

                if (findOptions.SearchDown)
                    moveToNextCell();
                else
                    moveToPrevCell();
            } while (!found && !endReached && !beginningReached);
        }

        private void frmFind_FindText(object sender, EventArgs e)
        {
            findOptions = sender as FindOptions;
            resetColors();
            //currentCell_Row = 0;
            //currentCell_Col = 0;
            setStartCell();
            findText(findOptions);
        }

        public static bool Contains(string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        private void tsbtnImport_Click(object sender, EventArgs e)
        {
            if (AssertDocx())
            {
                saveResxFiles(true);
                wordDocument.Import();
                MessageBox.Show(string.Format(LangHandler.GetString("statusImportOk_msg"), wordDocument.FilePath), 
                    LangHandler.GetString("statusImportExport_title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbtnExport_Click(object sender, EventArgs e)
        {
            if (AssertDocx())
            {
                wordDocument.Export();
                MessageBox.Show(string.Format(LangHandler.GetString("statusExportOk_msg"), wordDocument.FilePath), 
                    LangHandler.GetString("statusImportExport_title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool AssertDocx()
        {
            if (dataGridView.Rows.Count == 0 && dataGridView.Columns.Count == 0)
            {
                return false;
            }

            // return a new instance every time, as row count may have changed
            wordDocument = new WordDocument(dataGridView);

            return true;
        }
    }
}