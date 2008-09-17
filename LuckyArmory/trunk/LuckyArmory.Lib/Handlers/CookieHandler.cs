using System;
using System.Collections.Generic;
using System.Web;

namespace LuckyArmory.Lib.Handlers {

    public abstract class CookieHandler {

        protected CookieHandler() { }

        protected static HttpCookie GetCookie(string name) {
            return HttpContext.Current.Request.Cookies[name];
        }

        protected static void SaveCookie(HttpCookie cookie) {
            if (HttpContext.Current.Response.Cookies[cookie.Name] != null) {
                HttpContext.Current.Response.Cookies.Set(cookie);
            } else {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        protected static void AppendPair(string cookieName, string key, string value) {
            HttpCookie cookie = GetCookie(cookieName);

            if (cookie == null) {
                cookie = new HttpCookie(cookieName);
                cookie.Values.Add(key, value);

                SaveCookie(cookie);
            } else {
                if (cookie.Value.Contains(value) == false) {
                    cookie.Values.Add(key, value);
                    SaveCookie(cookie);
                }
            }
        }


        protected static void RemovePair(string cookieName, string newKey, string newValue) {
            HttpCookie cookie = GetCookie(cookieName);

            if (cookie != null) {
                cookie.Values.Remove(newKey);
                SaveCookie(cookie);
            }
        }
    }

}
