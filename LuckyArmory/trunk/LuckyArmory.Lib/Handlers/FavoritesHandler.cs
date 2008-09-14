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
            string newValue = ApplicationSettings.FavoritesQueryString(realm, name);
            newValue = HttpUtility.UrlEncode(newValue);

            string newKey = name + " of " + realm;
            newKey = HttpUtility.UrlEncode(newKey);

            CookieHandler.AppendPair(cookieName, newKey, newValue);
        }

        #endregion Save Favorite

        private static string cookieName = ApplicationSettings.FavoritesCookie;

    }

}
