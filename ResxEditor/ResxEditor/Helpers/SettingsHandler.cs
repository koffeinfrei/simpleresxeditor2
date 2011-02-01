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

        public event EventHandler SettingsChanged = delegate { };

        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Color3 { get; set; }
        public int Color4 { get; set; }
        public int Color5 { get; set; }
        public int SplitterH { get; set; }
        public int SplitterV { get; set; }
        public string Language { get; set; }
        public string BaseLanguage { get; set; }
        public Size MainWindowSize { get; set; }
        public Size PrefWindowSize { get; set; }
        public Size TranWindowSize { get; set; }
        public Size FindWindowSize { get; set; }
        public Point MainWindowPosition { get; set; }
        public Point PrefWindowPosition { get; set; }
        public Point TranWindowPosition { get; set; }
        public Point FindWindowPosition { get; set; }
        public FormWindowState MainWindowState { get; set; }
        public FormWindowState PrefWindowState { get; set; }
        public long LastUpdateCheck { get; set; }
        public bool SortByKeyOnSave { get; set; }
        public bool ShowKeyColumnOnStart { get; set; }
        public bool PromptForDocxPaths { get; set; }

        private void loadDefaultValues()
        {
            Color1 = Color.LightSalmon.ToArgb();
            Color2 = Color.LightGreen.ToArgb();
            Color3 = Color.LightSkyBlue.ToArgb();
            Color4 = Color.LightGray.ToArgb();
            Color5 = Color.Aquamarine.ToArgb();
            SplitterH = 100;
            SplitterV = 200;
            Language = "English";
            BaseLanguage = "en.resx";
            MainWindowSize = new Size(600, 300);
            PrefWindowSize = new Size(600, 400);
            TranWindowSize = new Size(400, 300);
            FindWindowSize = new Size(400, 250);
            MainWindowPosition = new Point();
            PrefWindowPosition = new Point();
            TranWindowPosition = new Point();
            FindWindowPosition = new Point();
            MainWindowState = FormWindowState.Normal;
            PrefWindowState = FormWindowState.Normal;
            LastUpdateCheck = DateTime.Now.AddDays(-2).Ticks;
            SortByKeyOnSave = false;
            ShowKeyColumnOnStart = false;
            PromptForDocxPaths = false;
        }
        
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
                    try
                    {
                        SettingsHandler settingsData = (SettingsHandler)serializer.Deserialize(reader);
                        instance.Color1 = settingsData.Color1;
                        instance.Color2 = settingsData.Color2;
                        instance.Color3 = settingsData.Color3;
                        instance.Color4 = settingsData.Color4;
                        instance.Color5 = settingsData.Color5;
                        instance.Language = settingsData.Language;
                        instance.BaseLanguage = settingsData.BaseLanguage;
                        instance.MainWindowSize = settingsData.MainWindowSize;
                        instance.PrefWindowSize = settingsData.PrefWindowSize;
                        instance.TranWindowSize = settingsData.TranWindowSize;
                        instance.FindWindowSize = settingsData.FindWindowSize;
                        instance.MainWindowPosition = settingsData.MainWindowPosition;
                        instance.PrefWindowPosition = settingsData.PrefWindowPosition;
                        instance.TranWindowPosition = settingsData.TranWindowPosition;
                        instance.FindWindowPosition = settingsData.FindWindowPosition;
                        instance.MainWindowState = settingsData.MainWindowState;
                        instance.PrefWindowState = settingsData.PrefWindowState;
                        instance.SplitterH = settingsData.SplitterH;
                        instance.SplitterV = settingsData.SplitterV;
                        instance.LastUpdateCheck = settingsData.LastUpdateCheck;
                        instance.SortByKeyOnSave = settingsData.SortByKeyOnSave;
                        instance.ShowKeyColumnOnStart = settingsData.ShowKeyColumnOnStart;
                        instance.PromptForDocxPaths = settingsData.PromptForDocxPaths;
                    }
                    catch(Exception ex)
                    {
                        // Can't use LangHandler here because it is not initialized yet
                        MessageBox.Show(ex.Message, "Unable to load settings, invalid format!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadDefaultValues();
                    }
                }
            }
            else
            {
                loadDefaultValues();
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