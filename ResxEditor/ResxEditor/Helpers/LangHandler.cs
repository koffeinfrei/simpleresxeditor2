using System.Collections.Generic;
using System.IO;

namespace ResxEditor.Forms
{
    class LangHandler
    {
        public static Dictionary<string, string> KV;

        public static string[] GetAvailableLanguages()
        {
            string[] languages;
            string fullpath = System.Windows.Forms.Application.StartupPath;
            languages = Directory.GetFiles(fullpath, "*.lang", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < languages.Length; i++)
            {
                languages[i] = languages[i].Remove(0, languages[i].LastIndexOf(Path.DirectorySeparatorChar) + 1);
                languages[i] = languages[i].Substring(0, languages[i].Length - 5).Trim();
            }

            return languages;
        }

        public static void LoadLanguage(string langName)
        {
            string basePath = System.Windows.Forms.Application.StartupPath;

            using (StreamReader reader = new StreamReader(Path.Combine(basePath, string.Format("{0}.lang", langName))))
            {
                string line;
                KV = new Dictionary<string, string>();

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == string.Empty || line.StartsWith("#"))
                        continue;

                    string[] keyValue = line.Split('=');

                    if (keyValue.Length != 2)
                        continue;

                    KV[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }
        }

        public static string GetString(string key)
        {
            if (KV.ContainsKey(key))
                return KV[key];
            else
                return string.Empty;
        }
    }
}