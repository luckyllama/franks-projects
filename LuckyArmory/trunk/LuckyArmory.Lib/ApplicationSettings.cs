using System.Configuration;

namespace LuckyArmory.Lib {

    /// <summary>
    /// Summary description for ApplicationSettings
    /// </summary>
    public class ApplicationSettings {

        private ApplicationSettings() { }

        public static string CharacterDataCacheDirectoryPath {
            get {
                return ConfigurationSettings.AppSettings["CharacterDataCacheFilePath"];
            }
        }

        #region Armory Settings

        public static string ArmorySearchUri(string realm, string name) {
            string uri = ConfigurationSettings.AppSettings["ArmorySearchUri"];

            uri = uri.Replace("{realm}", realm);
            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string ArmorySearchQueryString(string realm, string name) {
            string uri = ConfigurationSettings.AppSettings["ArmorySearchQueryString"];

            uri = uri.Replace("{realm}", realm);
            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string ArmoryUserAgent {
            get {
                return ConfigurationSettings.AppSettings["ArmoryUserAgent"];
            }
        }

        public static string ArmoryContentType {
            get {
                return ConfigurationSettings.AppSettings["ArmoryContentType"];
            }
        }

        #endregion Armory Settings

        #region Cookie Settings

        public static string FavoritesCookie {
            get {
                return ConfigurationSettings.AppSettings["FavoritesCookie"];
            }
        }

        public static string FavoritesQueryString(string realm, string name) {
            string uri = ConfigurationSettings.AppSettings["FavoritesQueryString"];

            uri = uri.Replace("{realm}", realm);
            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string SettingsCookie {
            get {
                return ConfigurationSettings.AppSettings["SettingsCookie"];
            }
        }

        #endregion Cookie Settings

        #region WoW Head Settings

        public static string WoWHeadItemXmlUri(int id) {
            string uri = ConfigurationSettings.AppSettings["WoWHeadItemXmlUri"];

            uri = uri.Replace("{id}", id.ToString());

            return uri;
        }

        public static string WoWHeadImageUri(string name) {
            string uri = ConfigurationSettings.AppSettings["WowHeadImageUri"];

            uri = uri.Replace("{name}", name);

            return uri;
        }

        public static string WoWHeadItemUri(int id) {
            string uri = ConfigurationSettings.AppSettings["WoWHeadItemUri"];

            uri = uri.Replace("{id}", id.ToString());

            return uri;
        }

        #endregion WoW Head Settings

    }

}