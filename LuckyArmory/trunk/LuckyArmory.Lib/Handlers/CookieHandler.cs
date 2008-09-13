using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyArmory.Lib.Handlers {

    internal class CookieHandler {

        private CookieHandler() { }

        #region Favorites Cookie Methods

        public static HttpCookie FavoritesCookie {
            get {
                return HttpContext.Current.Request.Cookies[ApplicationSettings.FavoritesCookie];
            }
        }

        public static void AddFavorite(string key, string value) {
            HttpCookie favoritesCookie = CookieHandler.FavoritesCookie;

            if (favoritesCookie == null) {
                favoritesCookie = new HttpCookie(ApplicationSettings.FavoritesCookie);
                favoritesCookie.Values.Add(key, value);

                HttpContext.Current.Response.Cookies.Add(favoritesCookie);
            } else {
                if (favoritesCookie.Value.Contains(value) == false) {
                    favoritesCookie.Values.Add(key, value);
                    HttpContext.Current.Response.Cookies.Set(favoritesCookie);
                }
            }
        }

        #endregion Favorites Cookie Methods

    }

}
