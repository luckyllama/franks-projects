using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LuckyWiki.Data;

namespace LuckyWiki.Mvc {
    public class LuckyWikiBaseViewUserControl : ViewUserControl {

        public IUser User {
            get {
                if (ViewContext.Controller is LuckyWikiBaseController) {
                    return ((LuckyWikiBaseController)ViewContext.Controller).User;
                }

                return null;
            }
        }

    }
}
