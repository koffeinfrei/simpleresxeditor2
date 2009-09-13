using System.Diagnostics;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void loadLanguageStrings()
        {
            Text = Global.GetNameWithVersion(LangHandler.KV["frmAbout"], string.Empty);

            // Labels
            lblCoded.Text = string.Format("{0} {1}", LangHandler.KV["lblCoded"], Global.GetAuthor());
            lblTranslated.Text = LangHandler.KV["lblTranslated"];

            // LinkLabels
            llblAuthor.Text = Global.GetEmail();

            // Buttons
            btnClose.Text = LangHandler.KV["btnClose"];
            btnWebsite.Text = LangHandler.KV["btnWebsite"];
        }

        #region Events

        private void FrmAbout_Load(object sender, System.EventArgs e)
        {
            loadLanguageStrings();
        }

        private void llblAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("mailto:{0}", Global.GetEmail()));
        }

        private void btnWebsite_Click(object sender, System.EventArgs e)
        {
            Process.Start(Global.GetURL());
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion
    }
}