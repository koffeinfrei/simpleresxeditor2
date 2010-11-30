using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ResxEditor.Forms
{
    public class Translator
    {
        private const string APP_ID = "6A08EF25D68839D6B8540D598366536816F6E073";
        private const string URL_Detect = "http://api.microsofttranslator.com/V1/Http.svc/Detect?appId={0}";
        private const string URL_Translate = "http://api.microsofttranslator.com/V1/Http.svc/Translate?appId={0}&from={1}&to={2}";
        private const string URL_GetLanguages = "http://api.microsofttranslator.com/V1/Http.svc/GetLanguages?appId={0}";
        private const string URL_GetLanguageNames = "http://api.microsofttranslator.com/V1/Http.svc/GetLanguageNames?appId={0}";

        public static string Translate(string codeFrom, string codeTo, string text)
        {
            string translatedText;
            string translateUri = string.Format(URL_Translate, APP_ID, codeFrom, codeTo);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(translateUri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.Timeout = 4000;
            httpWebRequest.ReadWriteTimeout = 2000;
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            try
            {
                httpWebRequest.ContentLength = bytes.Length;
                using (Stream os = httpWebRequest.GetRequestStream())
                    os.Write(bytes, 0, bytes.Length);


                using (WebResponse response = httpWebRequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                    translatedText = reader.ReadToEnd();

                return translatedText;

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(LangHandler.GetString("errorTranslator_msg"), ex.Message), LangHandler.GetString("errorTranslator_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}