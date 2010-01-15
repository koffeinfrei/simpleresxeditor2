using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmMain : Form
    {
        private readonly int SKIN_WIDTH = 352;
        private readonly int SKIN_HEIGHT = 32;
        private bool initialChanges;
        private bool unsavedChanges;

        public FrmMain()
        {
            InitializeComponent();

#if (DEBUG)
            string[] args = Environment.GetCommandLineArgs();
            //foreach (var s in args)
            //    MessageBox.Show(s);
            if (args.Length > 1) loadResxFiles(args);
#else       
            checkNewVersion();
#endif
        }

        private void loadSkin()
        {
            Bitmap bmp;

            // Load default skin
            imgListMain.Images.AddStrip(Properties.Resources.toolbar);

            // User-defined skin
            string skinFilename = Path.Combine(Application.StartupPath, "toolbar.png");

            if (File.Exists(skinFilename))
            {
                bmp = new Bitmap(skinFilename);
                // Check if it is a valid skin file
                if (bmp.Height == SKIN_HEIGHT && bmp.Width == SKIN_WIDTH)
                {
                    // Use user-defined skin
                    imgListMain.Images.Clear();
                    imgListMain.Images.AddStrip(bmp);
                }
            }

            tspMain.ImageList = imgListMain;

            tsbtnOpen.ImageIndex        = 0;
            tsbtnOpen.ImageScaling      = ToolStripItemImageScaling.SizeToFit;
            tsbtnSave.ImageIndex        = 1;
            tsbtnSave.ImageScaling      = ToolStripItemImageScaling.SizeToFit;
            tsbtnKeys.ImageIndex        = 2;
            tsbtnKeys.ImageScaling      = ToolStripItemImageScaling.SizeToFit;
            tsbtnFText.ImageIndex       = 3;
            tsbtnFText.ImageScaling     = ToolStripItemImageScaling.SizeToFit;
            tsbtnFAll.ImageIndex        = 4;
            tsbtnFAll.ImageScaling      = ToolStripItemImageScaling.SizeToFit;
            tsbtnHText.ImageIndex       = 5;
            tsbtnHText.ImageScaling     = ToolStripItemImageScaling.SizeToFit;
            tsbtnHDiffs.ImageIndex      = 6;
            tsbtnHDiffs.ImageScaling    = ToolStripItemImageScaling.SizeToFit;
            tsbtnHEquals.ImageIndex     = 7;
            tsbtnHEquals.ImageScaling   = ToolStripItemImageScaling.SizeToFit;
            tsbtnClear.ImageIndex       = 8;
            tsbtnClear.ImageScaling     = ToolStripItemImageScaling.SizeToFit;
            tsbtnSettings.ImageIndex    = 9;
            tsbtnSettings.ImageScaling  = ToolStripItemImageScaling.SizeToFit;
            tsbtnAbout.ImageIndex       = 10;
            tsbtnAbout.ImageScaling     = ToolStripItemImageScaling.SizeToFit;
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
                    dataGridView.Columns["keys"].Visible = false;
                    dataGridView.Columns["keys"].DefaultCellStyle.BackColor = Color.FromArgb(SettingsHandler.Instance.Color4);
                }

                int newColIndex = dataGridView.Columns.Add(file, Path.GetFileName(file));

                using (ResXResourceSet resourceSet = new ResXResourceSet(file))
                {
                    foreach (DictionaryEntry o in resourceSet)
                    {
                        object key = o.Key;
                        object value = o.Value;

                        int rowIndex = -1;

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            if ((string)dataGridView.Rows[row].Cells["keys"].Value == (string)key)
                            {
                                rowIndex = row;
                                break;
                            }
                        }

                        if (rowIndex == -1)
                        {
                            rowIndex = dataGridView.Rows.Add();
                            dataGridView.Rows[rowIndex].Cells["keys"].Value = key;
                        }

                        dataGridView.Rows[rowIndex].Cells[newColIndex].Value = value;
                    }
                }
            }

            dataGridView.ResumeLayout();
            initialChanges = false;
        }

        private void loadLanguageStrings()
        {
            Text = Global.GetNameWithVersion();
            tsbtnOpen.Text              = LangHandler.GetString("tsbtnOpen");
            tsbtnOpen.ToolTipText       = LangHandler.GetString("tsbtnOpen");
            tsbtnSave.Text              = LangHandler.GetString("tsbtnSave");
            tsbtnSave.ToolTipText       = LangHandler.GetString("tsbtnSave");
            tsbtnKeys.Text              = LangHandler.GetString("tsbtnKeys");
            tsbtnKeys.ToolTipText       = LangHandler.GetString("tsbtnKeys");
            tsbtnFText.Text             = LangHandler.GetString("tsbtnFText");
            tsbtnFText.ToolTipText      = LangHandler.GetString("tsbtnFText");
            tsbtnFAll.Text              = LangHandler.GetString("tsbtnFAll");
            tsbtnFAll.ToolTipText       = LangHandler.GetString("tsbtnFAll");
            tsbtnHDiffs.Text            = LangHandler.GetString("tsbtnHDiffs");
            tsbtnHDiffs.ToolTipText     = LangHandler.GetString("tsbtnHDiffs");
            tsbtnHEquals.Text           = LangHandler.GetString("tsbtnHEquals");
            tsbtnHEquals.ToolTipText    = LangHandler.GetString("tsbtnHEquals");
            tsbtnHText.Text             = LangHandler.GetString("tsbtnHText");
            tsbtnHText.ToolTipText      = LangHandler.GetString("tsbtnHText");
            tsbtnClear.Text             = LangHandler.GetString("tsbtnClear");
            tsbtnClear.ToolTipText      = LangHandler.GetString("tsbtnClear");
            tsbtnSettings.Text          = LangHandler.GetString("tsbtnSettings");
            tsbtnSettings.ToolTipText   = LangHandler.GetString("tsbtnSettings");
            tsbtnAbout.Text             = LangHandler.GetString("tsbtnAbout");
            tsbtnAbout.ToolTipText      = LangHandler.GetString("tsbtnAbout");
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

        private void saveResxFiles(bool askUnsaved)
        {
            try
            {
                if (askUnsaved)
                {
                    if (!unsavedChanges)
                    {
                        return;
                    }

                    if (DialogResult.No == MessageBox.Show(this, LangHandler.GetString("txtSave1"), LangHandler.GetString("txtSave2"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                }

                for (int column = 1; column < dataGridView.Columns.Count; column++)
                {
                    using (ResXResourceWriter resourceWriter = new ResXResourceWriter(dataGridView.Columns[column].Name))
                    {
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            if (dataGridView.Rows[row].Cells[column].Value != null)
                            {
                                resourceWriter.AddResource((string)dataGridView.Rows[row].Cells["keys"].Value, dataGridView.Rows[row].Cells[column].Value);
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
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if( e.Data.GetDataPresent(DataFormats.FileDrop,false))
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

        #endregion

        #region Events

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadSkin();
            loadLanguageStrings();
            SettingsHandler.SettingsChanged += new EventHandler(Settings_SettingsChanged);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveResxFiles(true);
            SettingsHandler.Instance.MainWindowState = WindowState;
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
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt  = "resx",
                Filter      = string.Format("{0}|*.resx", LangHandler.GetString("txtOpen1")),
                Multiselect = true,
                Title       = LangHandler.GetString("txtOpen2")
            };

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                loadResxFiles(openFileDialog.FileNames);
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            saveResxFiles(false);
        }

        private void tsbtnKeys_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Contains("keys"))
            {
                dataGridView.SuspendLayout();
                dataGridView.Columns["keys"].Visible = !dataGridView.Columns["keys"].Visible;
                dataGridView.ResumeLayout();
            }
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
            int numRows = dataGridView.Rows.Count - 1;
            dataGridView.SuspendLayout();
            for (int row = 0; row < numRows; row++)
                dataGridView.Rows[row].Visible = true;
            dataGridView.ResumeLayout();
            tsslStatus.Text = string.Format(LangHandler.GetString("statusFAll"), numRows);
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

            frmSettings.Show();
        }

        private void tsbtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        #endregion
    }
}