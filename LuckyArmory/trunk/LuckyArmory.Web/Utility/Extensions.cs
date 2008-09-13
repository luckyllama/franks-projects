using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyArmory.Web {

    public static class StringExtension {

        public static string UrlEncode(this string target) {
            target = HttpUtility.UrlEncode(target);

            return target;
        }

        public static string UrlDecode(this string target) {
            target = HttpUtility.UrlDecode(target);

            return target;
        }

    }

}
