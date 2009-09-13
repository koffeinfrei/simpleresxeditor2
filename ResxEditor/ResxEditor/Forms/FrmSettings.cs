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
            Text = LangHandler.KV["frmSettings"];

            // TabPages
            tpgInterface.Text = LangHandler.KV["tpgInterface"];
            tpgBehavior.Text = LangHandler.KV["tpgBehavior"];

            // Labels
            lblLanguage.Text = LangHandler.KV["lblLanguage"];
            lblColor1.Text = LangHandler.KV["lblColor1"];
            lblColor2.Text = LangHandler.KV["lblColor2"];
            lblColor3.Text = LangHandler.KV["lblColor3"];
            lblColor4.Text = LangHandler.KV["lblColor4"];
            lblColor5.Text = LangHandler.KV["lblColor5"];

            // Buttons
            btnSave.Text = LangHandler.KV["btnSave"];
            btnCancel.Text = LangHandler.KV["btnCancel"];
        }

        private void loadSettings()
        {
            //#Diff
            //Color1 = LightSalmon 255,160,122
            //#Equals
            //Color2 = LightGreen 144,238,144
            //#Unsavedcell
            //Color3 = LightSkyBlue 135,206,250
            //#Keys
            //Color4 = LightGray 211,211,211
            //#Text
            //Color5 = Aquamarine 127,255,212

            cmbLanguage.SelectedIndex = cmbLanguage.FindString(SettingsHandler.KV["Language"]);
            colorDialog1.Color = Color.FromName(SettingsHandler.KV["Color1"]);
            btnColor1.BackColor = Color.FromName(SettingsHandler.KV["Color1"]);
            colorDialog2.Color = Color.FromName(SettingsHandler.KV["Color2"]);
            btnColor2.BackColor = Color.FromName(SettingsHandler.KV["Color2"]);
            colorDialog3.Color = Color.FromName(SettingsHandler.KV["Color3"]);
            btnColor3.BackColor = Color.FromName(SettingsHandler.KV["Color3"]);
            colorDialog4.Color = Color.FromName(SettingsHandler.KV["Color4"]);
            btnColor4.BackColor = Color.FromName(SettingsHandler.KV["Color4"]);
            colorDialog5.Color = Color.FromName(SettingsHandler.KV["Color5"]);
            btnColor5.BackColor = Color.FromName(SettingsHandler.KV["Color5"]);
        }

        private void saveSettings()
        {
            SettingsHandler.KV["Language"] = cmbLanguage.SelectedItem.ToString();
            SettingsHandler.KV["Color1"] = btnColor1.BackColor.Name;
            SettingsHandler.KV["Color2"] = btnColor2.BackColor.Name;
            SettingsHandler.KV["Color3"] = btnColor3.BackColor.Name;
            SettingsHandler.KV["Color4"] = btnColor4.BackColor.Name;
            SettingsHandler.KV["Color5"] = btnColor5.BackColor.Name;
            SettingsHandler.Save();
        }
    }
}