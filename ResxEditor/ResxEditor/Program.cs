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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadExit += new EventHandler(Application_ThreadExit);

            // Read global settings
            SettingsHandler.Instance.Read();

            // Load localized strings
            LangHandler.LoadLanguage(SettingsHandler.Instance.Language);

            FrmMain frmMain = new FrmMain();
            
            if (SettingsHandler.Instance.MainWindowPosition.IsEmpty)
            {
                frmMain.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
            else
            {
                frmMain.StartPosition = FormStartPosition.Manual;
                frmMain.Location = SettingsHandler.Instance.MainWindowPosition;
            }

            frmMain.Size = SettingsHandler.Instance.MainWindowSize;
            frmMain.WindowState = SettingsHandler.Instance.MainWindowState;

            Application.Run(frmMain);
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            SettingsHandler.Instance.Save();
        }
    }
}