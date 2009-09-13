using System.Windows.Forms;

namespace ResxEditor.Helpers
{
    class Global
    {
        private static readonly string NAME = "Simple Resx Editor";
        private static readonly string AUTHOR = "Matías E. Palomeque";
        private static readonly string EMAIL = "matias.ar@gmail.com";
        private static readonly string URL_WEBSITE = "http://simpleresxeditor.blogspot.com";
        private static readonly string URL_VERSION = "http://cablemodem.fibertel.com.ar/qwerty/sre/version.txt";

        public static string GetAuthor()
        {
            return AUTHOR;
        }

        public static string GetEmail()
        {
            return EMAIL;
        }

        public static string GetURL()
        {
            return URL_WEBSITE;
        }

        public static string GetURLVersion()
        {
            return URL_VERSION;
        }

        public static string GetVersion()
        {
            return Application.ProductVersion;
        }

        public static string GetNameWithVersion()
        {
            return GetNameWithVersion(string.Empty, string.Empty);
        }

        public static string GetNameWithVersion(string preText, string postText)
        {
            var version = Application.ProductVersion.Split('.');

            if (!string.IsNullOrEmpty(preText))
            {
                preText = string.Format("{0} ", preText);
            }

            if (!string.IsNullOrEmpty(postText))
            {
                postText = string.Format(" {0}", postText);
            }

            if (version[2].Equals("0"))
            {
                return string.Format("{0}{1} v{2}.{3}{4}", preText, NAME, version[0], version[1], postText);
            }
            else
            {
                return string.Format("{0}{1} v{2}.{3}.{4}{5}", preText, NAME, version[0], version[1], version[2], postText);
            }
        }
    }
}