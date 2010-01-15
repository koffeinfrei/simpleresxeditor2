using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ResxEditor.Forms;

namespace ResxEditor.Helpers
{
    class Updater
    {
        public static void CheckForUpdates()
        {
            string currentVersion = Global.GetVersion();
            string onlineVersion = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(Global.GetURLVersion());
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    onlineVersion = stream.ReadToEnd();
                }

                if (Regex.IsMatch(onlineVersion, @"(\d+)\.(\d+)\.(\d+)\.(\d+)"))
                {
                    if (!currentVersion.Equals(onlineVersion))
                    {
                        if (DialogResult.Yes == MessageBox.Show(LangHandler.GetString("txtDown1"), LangHandler.GetString("txtDown2"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Process.Start(Global.GetURL());
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}