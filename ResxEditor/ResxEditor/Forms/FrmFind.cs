using System;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmFind : BaseForm
    {
        public event EventHandler FindText = delegate { };

        public FrmFind()
        {
            InitializeComponent();
            loadLanguageStrings();
        }

        public FrmFind(FindOptions options)
            : this()
        {
            if (options == null)
                return;

            txtTextToFind.Text = options.TextToFind;
            ckbCaseSensitive.Checked = options.CaseSensitive;
        }

        private void loadLanguageStrings(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                loadLanguageStrings(control);
            }
        }

        private void loadLanguageStrings(Control control)
        {
            control.Text = LangHandler.GetString(control.Name);
            if (control.HasChildren)
                loadLanguageStrings(control.Controls);
        }

        private void loadLanguageStrings()
        {
            loadLanguageStrings(this.Controls);
        }

        public void EnableReplace()
        {
            Text = LangHandler.GetString("FrmFindReplace");
            btnReplace.Visible = true;
            btnReplaceAll.Visible = true;
            txtReplaceWith.Enabled = true;
        }

        public void DisableReplace()
        {
            Text = LangHandler.GetString("FrmFind");
            btnReplace.Visible = false;
            btnReplaceAll.Visible = false;
            txtReplaceWith.Enabled = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.F:
                    DisableReplace();
                    return true;
                case Keys.Control | Keys.H:
                    EnableReplace();
                    return true;
                case Keys.Escape:
                    Close();
                    return true;
            }

            return false;
        }

        private void findText(FindOptions options)
        {
            if (options.TextToFind != null && options.TextToFind.Length > 0)
            {
                FindText(options, EventArgs.Empty);
            }
        }

        private void btnReplace_Click(object sender, System.EventArgs e)
        {

        }

        private void btnReplaceAll_Click(object sender, System.EventArgs e)
        {

        }

        private void btnFindPrevious_Click(object sender, System.EventArgs e)
        {
            findText(new FindOptions()
            {
                CaseSensitive = ckbCaseSensitive.Checked,
                SearchDown = false,
                TextToFind = txtTextToFind.Text,
                WarpAround = true
            });

            Close();
        }

        private void btnFindNext_Click(object sender, System.EventArgs e)
        {
            findText(new FindOptions()
            {
                CaseSensitive = ckbCaseSensitive.Checked,
                SearchDown = true,
                TextToFind = txtTextToFind.Text,
                WarpAround = true
            });

            Close();
        }

        private void FrmFind_ResizeEnd(object sender, EventArgs e)
        {
            SettingsHandler.Instance.FindWindowSize = Size;
        }

        private void FrmFind_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                SettingsHandler.Instance.FindWindowPosition = Location;
        }

        private void FrmFind_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmFind_Load(object sender, EventArgs e)
        {
            SettingsHandler.Instance.SettingsChanged += new EventHandler(Instance_SettingsChanged);
        }

        private void Instance_SettingsChanged(object sender, EventArgs e)
        {
            loadLanguageStrings();
        }
    }

    public class FindOptions
    {
        public string TextToFind { get; set; }
        public bool WarpAround { get; set; }
        public bool SearchDown { get; set; }
        public bool CaseSensitive { get; set; }
    }
}