using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace iWoWArm.Handlers {

    public class FavoritesHandler {

        private FavoritesHandler() { }

        #region Get Favorites

        public static IDictionary<string, string> GetFavorites() {
            IDictionary<string, string> favorites = new Dictionary<string, string>();

            NameValueCollection cookieValue = getFavoritesFromCookie();

            if (cookieValue.Count != 0) {
                foreach (string favorite in cookieValue.AllKeys) {
                    string queryString = HttpUtility.UrlDecode(cookieValue[favorite]);
                    favorites.Add(favorite, queryString);
                }
            }

            return favorites;
        }

        private static NameValueCollection getFavoritesFromCookie() {
            HttpCookie favoritesCookie = CookieHandler.FavoritesCookie;

            if (favoritesCookie == null) {
                return new NameValueCollection();
            } else {
                return favoritesCookie.Values;
            }
        }

        #endregion Get Favorites

        #region Save Favorite

        public static void SaveNewFavorite(string realm, string name) {
            string newValue = ApplicationSettings.ArmorySearchQueryString(realm, name);

            newValue = HttpUtility.UrlEncode(newValue);
            string newKey = name + " of " + realm;

            CookieHandler.AddFavorite(newKey, newValue);
        }

        #endregion Save Favorite

    }

}
