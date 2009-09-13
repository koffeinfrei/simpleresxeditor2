using System;
using System.Windows.Forms;
using ResxEditor.Forms;
using ResxEditor.Helpers;

namespace ResxEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Read global settings
            Helpers.SettingsHandler.Read();

            // Load localized strings
            Forms.LangHandler.LoadLanguage(SettingsHandler.KV["Language"]);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
