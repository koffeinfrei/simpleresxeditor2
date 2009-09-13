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
            
#if (!DEBUG)
            checkNewVersion();
#else            
            string[] args = Environment.GetCommandLineArgs();
            foreach (var s in args)
                MessageBox.Show(s);
            if (args.Length > 1) loadResxFiles(args);
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
            if (unsavedChanges)
            {
                if (DialogResult.Yes == MessageBox.Show(this, LangHandler.KV["txtSave1"], LangHandler.KV["txtSave2"], MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    saveResxFiles();
                    unsavedChanges = false;
                }
            }

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
                    dataGridView.Columns["keys"].DefaultCellStyle.BackColor = Color.FromName(SettingsHandler.KV["Color4"]);
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
            tsbtnOpen.Text              = LangHandler.KV["tsbtnOpen"];
            tsbtnOpen.ToolTipText       = LangHandler.KV["tsbtnOpen"];
            tsbtnSave.Text              = LangHandler.KV["tsbtnSave"];
            tsbtnSave.ToolTipText       = LangHandler.KV["tsbtnSave"];
            tsbtnKeys.Text              = LangHandler.KV["tsbtnKeys"];
            tsbtnKeys.ToolTipText       = LangHandler.KV["tsbtnKeys"];
            tsbtnFText.Text             = LangHandler.KV["tsbtnFText"];
            tsbtnFText.ToolTipText      = LangHandler.KV["tsbtnFText"];
            tsbtnFAll.Text              = LangHandler.KV["tsbtnFAll"];
            tsbtnFAll.ToolTipText       = LangHandler.KV["tsbtnFAll"];
            tsbtnHDiffs.Text            = LangHandler.KV["tsbtnHDiffs"];
            tsbtnHDiffs.ToolTipText     = LangHandler.KV["tsbtnHDiffs"];
            tsbtnHEquals.Text           = LangHandler.KV["tsbtnHEquals"];
            tsbtnHEquals.ToolTipText    = LangHandler.KV["tsbtnHEquals"];
            tsbtnHText.Text             = LangHandler.KV["tsbtnHText"];
            tsbtnHText.ToolTipText      = LangHandler.KV["tsbtnHText"];
            tsbtnClear.Text             = LangHandler.KV["tsbtnClear"];
            tsbtnClear.ToolTipText      = LangHandler.KV["tsbtnClear"];
            tsbtnSettings.Text          = LangHandler.KV["tsbtnSettings"];
            tsbtnSettings.ToolTipText   = LangHandler.KV["tsbtnSettings"];
            tsbtnAbout.Text             = LangHandler.KV["tsbtnAbout"];
            tsbtnAbout.ToolTipText      = LangHandler.KV["tsbtnAbout"];
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
                    tsslStatus.Text = string.Format(LangHandler.KV["statusHEquals"], numColumns * numRows - numDiffs);
                else
                    tsslStatus.Text = string.Format(LangHandler.KV["statusHDiffs"], numDiffs);
            }
        }

        private void saveResxFiles()
        {
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

        private void resetColors()
        {
            dataGridView.SuspendLayout();
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Empty;
                dataGridView.Rows[row].Cells["keys"].Style.BackColor = Color.FromName(SettingsHandler.KV["Color4"]);
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
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromName(SettingsHandler.KV["Color3"]);
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
            if (unsavedChanges)
            {
                if (DialogResult.Yes == MessageBox.Show(this, LangHandler.KV["txtSave1"], LangHandler.KV["txtSave2"], MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    saveResxFiles();
                    unsavedChanges = false;
                }
            }
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
                Filter      = string.Format("{0}|*.resx", LangHandler.KV["txtOpen1"]),
                Multiselect = true,
                Title       = LangHandler.KV["txtOpen2"]
            };

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                loadResxFiles(openFileDialog.FileNames);
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            saveResxFiles();
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

                tsslStatus.Text = string.Format(LangHandler.KV["statusFText"], numTextRows, numRows);
            }
        }

        private void tsbtnFAll_Click(object sender, EventArgs e)
        {
            int numRows = dataGridView.Rows.Count - 1;
            dataGridView.SuspendLayout();
            for (int row = 0; row < numRows; row++)
                dataGridView.Rows[row].Visible = true;
            dataGridView.ResumeLayout();
            tsslStatus.Text = string.Format(LangHandler.KV["statusFAll"], numRows);
        }

        private void tsbtnHDiffs_Click(object sender, EventArgs e)
        {
            checkDiffs(false, Color.FromName(SettingsHandler.KV["Color1"]), Color.Empty);
        }

        private void tsbtnHEquals_Click(object sender, EventArgs e)
        {
            checkDiffs(true, Color.Empty, Color.FromName(SettingsHandler.KV["Color2"]));
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
                        dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.FromName(SettingsHandler.KV["Color5"]);
                        numTextCells++;
                    }
                    else
                    {
                        dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Empty;
                    }
                }
                dataGridView.ResumeLayout();

                tsslStatus.Text = string.Format(LangHandler.KV["statusHText"], numTextCells);
            }
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            resetColors();
            tsslStatus.Text = LangHandler.KV["statusClear"];
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show(this);
        }

        private void tsbtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        #endregion
    }
}