using System;
using System.Collections.Generic;
using System.IO;

namespace ResxEditor.Helpers
{
    class SettingsHandler
    {
        public static event EventHandler SettingsChanged;

        // These are default settings and will be overwritten if settings.ini exists
        public static Dictionary<string, string> KV = new Dictionary<string, string>() {
            { "Color1", "LightSalmon" },
            { "Color2", "LightGreen" },
            { "Color3", "LightSkyBlue" },
            { "Color4", "LightGray" },
            { "Color5", "Aquamarine" },
            { "Language", "English" }
        };

        public static void Read()
        {
            string writableFilename = GetWritableFilename();

            // If no path is returned then there is nothing to read
            if (string.IsNullOrEmpty(writableFilename))
                return;

            using (StreamReader reader = new StreamReader(writableFilename))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Avoid empty lines or comments
                    if (line == string.Empty || line.StartsWith("#"))
                        continue;

                    string[] keyValue = line.Split('=');

                    // There is a missing key or value
                    if (keyValue.Length != 2)
                        continue;

                    KV[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }
        }

        public static void Save()
        {
            string writableFilename = GetWritableFilename();

            if (string.IsNullOrEmpty(writableFilename))
                return;

            using (StreamWriter writer = new StreamWriter(writableFilename))
            {
                foreach (var item in KV)
                {
                    writer.WriteLine(string.Format("{0} = {1}", item.Key, item.Value));
                }
            }

            if (SettingsChanged != null)
                SettingsChanged(null, EventArgs.Empty);
        }

        private static string GetWritableFilename()
        {
            string settingsFilename = "settings.ini";
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