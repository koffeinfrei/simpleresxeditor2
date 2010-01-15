using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ResxEditor.Helpers
{
    public sealed class SettingsHandler
    {
        #region Singleton

        static readonly SettingsHandler instance = new SettingsHandler();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SettingsHandler()
        {
        }

        SettingsHandler()
        {
        }

        public static SettingsHandler Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        public static event EventHandler SettingsChanged;
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Color3 { get; set; }
        public int Color4 { get; set; }
        public int Color5 { get; set; }
        public string Language { get; set; }
        public Size MainWindowSize { get; set; }
        public Size PrefWindowSize { get; set; }
        public Point MainWindowPosition { get; set; }
        public Point PrefWindowPosition { get; set; }
        public FormWindowState MainWindowState { get; set; }
        public FormWindowState PrefWindowState { get; set; }

        public void Read()
        {
            string writableFilename = getWritableFilename();

            // If no path is returned then there is nothing to read
            if (string.IsNullOrEmpty(writableFilename))
                return;

            FileInfo fileInfo = new FileInfo(writableFilename);

            if (File.Exists(writableFilename) && fileInfo.Length != 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsHandler));
                using (StreamReader reader = new StreamReader(writableFilename))
                {
                    SettingsHandler settingsData = (SettingsHandler)serializer.Deserialize(reader);
                    instance.Color1 = settingsData.Color1;
                    instance.Color2 = settingsData.Color2;
                    instance.Color3 = settingsData.Color3;
                    instance.Color4 = settingsData.Color4;
                    instance.Color5 = settingsData.Color5;
                    instance.Language = settingsData.Language;
                    instance.MainWindowSize = settingsData.MainWindowSize;
                    instance.PrefWindowSize = settingsData.PrefWindowSize;
                    instance.MainWindowPosition = settingsData.MainWindowPosition;
                    instance.PrefWindowPosition = settingsData.PrefWindowPosition;
                    instance.MainWindowState = settingsData.MainWindowState;
                    instance.PrefWindowState = settingsData.PrefWindowState;
                }
            }
            else
            {
                SettingsHandler.Instance.loadDefaultSettings();
            }
        }

        public void Save()
        {
            string writableFilename = getWritableFilename();

            if (string.IsNullOrEmpty(writableFilename))
                return;

            XmlSerializer serialized = new XmlSerializer(typeof(SettingsHandler));

            using (StreamWriter writer = new StreamWriter(writableFilename))
                serialized.Serialize(writer, Instance);

            if (SettingsChanged != null)
                SettingsChanged(null, EventArgs.Empty);
        }

        private void loadDefaultSettings()
        {
            Color1 = Color.LightSalmon.ToArgb();
            Color2 = Color.LightGreen.ToArgb();
            Color3 = Color.LightSkyBlue.ToArgb();
            Color4 = Color.LightGray.ToArgb();
            Color5 = Color.Aquamarine.ToArgb();
            Language = "English";
            MainWindowSize = new Size(600, 300);
            MainWindowState = FormWindowState.Normal;
            MainWindowPosition = new Point();
            PrefWindowSize = new Size(600, 400);
            PrefWindowState = FormWindowState.Normal;
            PrefWindowPosition = new Point();
        }

        private string getWritableFilename()
        {
            string settingsFilename = "settings.xml";
            string[] possiblePaths = new string[] {
                System.Windows.Forms.Application.StartupPath,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Simple Resx Editor")
            };

            foreach (var item in possiblePaths)
            {
                string settingsFullpath;

                try
                {
                    if (!File.Exists(settingsFullpath = Path.Combine(item, settingsFilename)))
                    {
                        File.CreateText(settingsFullpath).Close();
                        return settingsFullpath;
                    }
                    else
                    {
                        return settingsFullpath;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            return string.Empty;
        }
    }
}