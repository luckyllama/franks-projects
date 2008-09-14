using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyArmory.Lib.WoW;
using LuckyArmory.Lib;

namespace LuckyArmory.Web.Views.Info {

    public partial class Gear : ViewPage {

        protected void Page_Load(object sender, EventArgs e) {
            GearRepeater.DataSource = ViewData["Gear"];
            GearRepeater.DataBind();
        }

        protected string GetSlotName(object id) {
            return GearInformation.GetSlotName(Convert.ToInt32(id));
        }

        protected string GetIconImagePath(object name) {
            return ApplicationSettings.WoWHeadImageUri(name.ToString());
        }

        protected string GetWoWHeadItemXmlPath(object itemId) {
            return ApplicationSettings.WoWHeadItemXmlUri(Convert.ToInt32(itemId));
        }

        protected string GetWoWHeadItemPath(object itemId) {
            return ApplicationSettings.WoWHeadItemUri(Convert.ToInt32(itemId));
        }
    }
}
