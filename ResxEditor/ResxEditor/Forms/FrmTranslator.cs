using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ResxEditor.Helpers;

namespace ResxEditor.Forms
{
    public partial class FrmTranslator : BaseForm
    {
        class Language
        {
            string Name;
            string Code;

            public Language(string Name, string Code)
            {
                this.Name = Name;
                this.Code = Code;
            }

            public string GetCode()
            {
                return Code;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private readonly string APP_ID = "6A08EF25D68839D6B8540D598366536816F6E073";
        private readonly string URL_Detect = "http://api.microsofttranslator.com/V1/Http.svc/Detect?appId={0}";
        private readonly string URL_Translate = "http://api.microsofttranslator.com/V1/Http.svc/Translate?appId={0}&from={1}&to={2}";
        private readonly string URL_GetLanguages = "http://api.microsofttranslator.com/V1/Http.svc/GetLanguages?appId={0}";
        private readonly string URL_GetLanguageNames = "http://api.microsofttranslator.com/V1/Http.svc/GetLanguageNames?appId={0}";

        BackgroundWorker wrkTranslation = new BackgroundWorker();
        BackgroundWorker wrkDetection = new BackgroundWorker();

        public FrmTranslator()
        {
            InitializeComponent();

            wrkTranslation.DoWork += new DoWorkEventHandler(wrkTranslation_DoWork);
            wrkTranslation.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wrkTranslation_RunWorkerCompleted);

            wrkDetection.DoWork += new DoWorkEventHandler(wrkDetection_DoWork);
            wrkDetection.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wrkDetection_RunWorkerCompleted);
        }
        
        private void wrkDetection_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = e.Argument as string;
            string locale = string.Empty;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(URL_Detect, APP_ID));
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "text/plain";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Stream os = null;

            try
            {
                httpWebRequest.ContentLength = bytes.Length;
                os = httpWebRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    locale = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auto-Detection is not working right now, please select the source language.\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            e.Result = locale;
        }

        private void wrkDetection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null || e.Result.ToString() == string.Empty)
                return;

            foreach (Language item in cboxFrom.Items)
            {
                if (item.GetCode().ToLower() == e.Result.ToString().ToLower())
                {
                    cboxFrom.SelectedItem = item;
                    break;
                }
            }
        }

        private void wrkTranslation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtResult.Text = e.Result.ToString();
        }

        private void wrkTranslation_DoWork(object sender, DoWorkEventArgs e)
        {
            var param = (string[])e.Argument;
            string translated = translate(param[0], param[1], param[2]);
            e.Result = translated;
        }

        private void FrmTranslator_Load(object sender, EventArgs e)
        {
            loadLanguageStrings();
            ThreadPool.QueueUserWorkItem(getSupportedLanguages);
        }

        private void getSupportedLanguages(object o)
        {
            string langCode;
            string[] langCodes;
            string langName;
            string[] langNames;
            WebRequest request1 = WebRequest.Create(string.Format(URL_GetLanguages, APP_ID));
            using (WebResponse response = request1.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                langCode = reader.ReadToEnd();
            }

            WebRequest request2 = WebRequest.Create(string.Format(URL_GetLanguageNames, APP_ID));
            using (WebResponse response = request2.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                langName = reader.ReadToEnd();
            }

            langCodes = langCode.Replace("\r", string.Empty).Split('\n');
            langNames = langName.Replace("\r", string.Empty).Split('\n');

            for (int i = 0; i < langNames.Length; i++)
            {
                if (langNames[i].Length == 0 && langCodes[i].Length == 0)
                    continue;
                Language l = new Language(langNames[i], langCodes[i]);
                this.Invoke(new MethodInvoker(delegate
                    {
                        cboxFrom.Items.Add(l);
                        cboxTo.Items.Add(l);
                    }));
            }
        }

        private void loadLanguageStrings()
        {
            Text = LangHandler.GetString("frmTranslator");

            // Labels
            lblLanguages.Text = LangHandler.GetString("lblLanguages");

            // LinkLabels
            llblClearAll.Text = LangHandler.GetString("llblClearAll");
            llblCopy1.Text = LangHandler.GetString("llblCopy1");
            llblCopy2.Text = LangHandler.GetString("llblCopy2");

            // Buttons
            btnSwap.Text = LangHandler.GetString("btnSwap");
            btnTranslate.Text = LangHandler.GetString("btnTranslate");

            cboxFrom.Items.Add(new Language(LangHandler.GetString("itemAutoDetect"), string.Empty));
        }

        private void getTranslation()
        {
            if (cboxFrom.SelectedIndex == -1)
                cboxFrom.SelectedIndex = 0;

            if (txtSource.Text.Length == 0 || cboxFrom.SelectedIndex == -1 || cboxTo.SelectedIndex == -1)
                return;

            if (!wrkDetection.IsBusy && cboxFrom.SelectedIndex == 0)
                wrkDetection.RunWorkerAsync(txtSource.Text);

            if (!wrkTranslation.IsBusy)
                wrkTranslation.RunWorkerAsync(new string[] { ((Language)cboxFrom.SelectedItem).GetCode(), ((Language)cboxTo.SelectedItem).GetCode(), txtSource.Text });
        }

        private string translate(string codeFrom, string codeTo, string text)
        {
            string translatedText = string.Empty;
            string translateUri = string.Format(URL_Translate, APP_ID, codeFrom, codeTo);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(translateUri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "text/plain";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Stream os = null;

            try
            {
                httpWebRequest.ContentLength = bytes.Length;
                os = httpWebRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            using (WebResponse response = httpWebRequest.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                translatedText = reader.ReadToEnd();
            }

            return translatedText;
        }

        private void llblCopy1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
                return;
            Clipboard.SetText(txtSource.Text);
        }

        private void llblCopy2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
                return;
            Clipboard.SetText(txtResult.Text);
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            getTranslation();
        }

        private void llblClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtResult.Clear();
            txtSource.Clear();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (cboxFrom.SelectedIndex == 0 || cboxFrom.SelectedIndex == -1 || cboxTo.SelectedIndex == -1)
                return;

            var aux = ((Language)cboxFrom.SelectedItem);
            cboxFrom.SelectedItem = cboxTo.SelectedItem;
            cboxTo.SelectedItem = aux;

            getTranslation();
        }

        private void FrmTranslator_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsHandler.Instance.TranWindowPosition = Location;
            SettingsHandler.Instance.TranWindowSize = Size;
        }

        private void cboxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxFrom.SelectedIndex == -1 || cboxTo.SelectedIndex == -1)
                return;
            Text = string.Format("{0} - {1}: {2}", cboxFrom.SelectedItem, cboxTo.SelectedItem, LangHandler.GetString("frmTranslator"));
        }

        private void cboxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxFrom.SelectedIndex == -1 || cboxTo.SelectedIndex == -1)
                return;
            Text = string.Format("{0} - {1}: {2}", cboxFrom.SelectedItem, cboxTo.SelectedItem, LangHandler.GetString("frmTranslator"));
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSource.Text.Length > 0)
            {
                getTranslation();
            }
        }
    }
}