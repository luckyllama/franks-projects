using System.Configuration;

namespace iWoWArm {

    /// <summary>
    /// Summary description for ApplicationSettings
    /// </summary>
    public class ApplicationSettings {

        private ApplicationSettings() { }

        public static string CharacterDataCacheDirectoryPath {
            get {
                return ConfigurationManager.AppSettings["CharacterDataCacheFilePath"]; ;
            }
        }

        #region Armory Settings

        public static string ArmorySearchUri(string realm, string name) {
            string uri = ConfigurationManager.AppSettings["ArmorySearchUri"];

            uri = uri.Replace("{realm}", realm);
            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string ArmorySearchQueryString(string realm, string name) {
            string uri = ConfigurationManager.AppSettings["ArmorySearchQueryString"];

            uri = uri.Replace("{realm}", realm);
            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string ArmoryUserAgent {
            get {
                return ConfigurationManager.AppSettings["ArmoryUserAgent"];
            }
        }

        public static string ArmoryContentType {
            get {
                return ConfigurationManager.AppSettings["ArmoryContentType"];
            }
        }

        #endregion Armory Settings

        #region Cookie Settings

        public static string FavoritesCookie {
            get {
                return ConfigurationManager.AppSettings["FavoritesCookie"]; ;
            }
        }

        public static string SettingsCookie {
            get {
                return ConfigurationManager.AppSettings["SettingsCookie"]; ;
            }
        }

        #endregion Cookie Settings

    }

}