using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace LuckyArmory.Lib.Handlers {

    public class FavoritesHandler : CookieHandler {

        protected FavoritesHandler() { }

        #region Get Favorites

        public static IDictionary<string, string> GetFavorites() {
            IDictionary<string, string> favorites = new Dictionary<string, string>();

            NameValueCollection cookieValue = getFavoritesFromCookie();

            if (cookieValue.Count != 0) {
                foreach (string favorite in cookieValue.AllKeys) {
                    string queryString = HttpUtility.UrlDecode(cookieValue[favorite]);
                    string text = HttpUtility.UrlDecode(favorite).Replace('+', ' ');
                    favorites.Add(text, queryString);
                }
            }

            return favorites;
        }

        private static NameValueCollection getFavoritesFromCookie() {
            HttpCookie favoritesCookie = CookieHandler.GetCookie(cookieName);

            if (favoritesCookie == null) {
                return new NameValueCollection();
            } else {
                return favoritesCookie.Values;
            }
        }

        #endregion Get Favorites

        #region Save Favorite

        public static void SaveNewFavorite(string realm, string name) {
            string newKey = getCookiePairKey(realm, name);
            string newValue = getCookiePairValue(realm, name);

            CookieHandler.AppendPair(cookieName, newKey, newValue);
        }

        #endregion Save Favorite

        #region Delete Favorite 

        public static void DeleteFavorite(string realm, string name) {
            string newKey = getCookiePairKey(realm, name);
            string newValue = getCookiePairValue(realm, name);

            CookieHandler.RemovePair(cookieName, newKey, newValue);
        }

        #endregion Delete Favorite 

        #region Util

        private static string getCookiePairValue(string realm, string name) {
            string newValue = ApplicationSettings.FavoritesQueryString(realm, name);
            newValue = HttpUtility.UrlEncode(newValue);
            return newValue;
        }

        private static string getCookiePairKey(string realm, string name) {
            string newKey = name + " of " + realm;
            newKey = HttpUtility.UrlEncode(newKey);
            return newKey;
        }

        #endregion Util

        private static string cookieName = ApplicationSettings.FavoritesCookie;

    }

}
