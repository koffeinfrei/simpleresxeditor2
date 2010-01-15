using System;
using System.Drawing;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        #region Events

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            // Load available languages
            cmbLanguage.Items.AddRange(Forms.LangHandler.GetAvailableLanguages());

            // Load translated UI strings
            loadLanguageStrings();

            loadSettings();
        }

        private void FrmSettings_ResizeEnd(object sender, EventArgs e)
        {
            SettingsHandler.Instance.PrefWindowSize = Size;
        }

        private void FrmSettings_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                SettingsHandler.Instance.PrefWindowPosition = Location;
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsHandler.Instance.PrefWindowState = WindowState;
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                btnColor1.BackColor = colorDialog1.Color;
            }
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog2.ShowDialog())
            {
                btnColor2.BackColor = colorDialog2.Color;
            }
        }

        private void btnColor3_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog3.ShowDialog())
            {
                btnColor3.BackColor = colorDialog3.Color;
            }
        }

        private void btnColor4_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog4.ShowDialog())
            {
                btnColor4.BackColor = colorDialog4.Color;
            }
        }

        private void btnColor5_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog5.ShowDialog())
            {
                btnColor5.BackColor = colorDialog5.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LangHandler.LoadLanguage(cmbLanguage.SelectedItem.ToString());
        }

        #endregion

        private void loadLanguageStrings()
        {
            Text = LangHandler.GetString("frmSettings");

            // TabPages
            tpgInterface.Text = LangHandler.GetString("tpgInterface");
            tpgBehavior.Text = LangHandler.GetString("tpgBehavior");

            // Labels
            lblLanguage.Text = LangHandler.GetString("lblLanguage");
            lblColor1.Text = LangHandler.GetString("lblColor1");
            lblColor2.Text = LangHandler.GetString("lblColor2");
            lblColor3.Text = LangHandler.GetString("lblColor3");
            lblColor4.Text = LangHandler.GetString("lblColor4");
            lblColor5.Text = LangHandler.GetString("lblColor5");

            // Buttons
            btnSave.Text = LangHandler.GetString("btnSave");
            btnCancel.Text = LangHandler.GetString("btnCancel");
        }

        private void loadSettings()
        {
            cmbLanguage.SelectedIndex = cmbLanguage.FindString(SettingsHandler.Instance.Language);
            colorDialog1.Color = Color.FromArgb(SettingsHandler.Instance.Color1);
            btnColor1.BackColor = Color.FromArgb(SettingsHandler.Instance.Color1);
            colorDialog2.Color = Color.FromArgb(SettingsHandler.Instance.Color2);
            btnColor2.BackColor = Color.FromArgb(SettingsHandler.Instance.Color2);
            colorDialog3.Color = Color.FromArgb(SettingsHandler.Instance.Color3);
            btnColor3.BackColor = Color.FromArgb(SettingsHandler.Instance.Color3);
            colorDialog4.Color = Color.FromArgb(SettingsHandler.Instance.Color4);
            btnColor4.BackColor = Color.FromArgb(SettingsHandler.Instance.Color4);
            colorDialog5.Color = Color.FromArgb(SettingsHandler.Instance.Color5);
            btnColor5.BackColor = Color.FromArgb(SettingsHandler.Instance.Color5);
        }

        private void saveSettings()
        {
            SettingsHandler.Instance.Language = cmbLanguage.SelectedItem.ToString();
            SettingsHandler.Instance.Color1 = btnColor1.BackColor.ToArgb();
            SettingsHandler.Instance.Color2 = btnColor2.BackColor.ToArgb();
            SettingsHandler.Instance.Color3 = btnColor3.BackColor.ToArgb();
            SettingsHandler.Instance.Color4 = btnColor4.BackColor.ToArgb();
            SettingsHandler.Instance.Color5 = btnColor5.BackColor.ToArgb();
            SettingsHandler.Instance.Save();
        }
    }
}