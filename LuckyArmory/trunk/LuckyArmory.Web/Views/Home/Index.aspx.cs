using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyArmory.Web.Views.Home {
    public partial class Index : ViewPage {

        public void Page_Load() {
            dataBindFavoriteCharacters();
        }

        private void dataBindFavoriteCharacters() {
            FavoritesRepeater.DataSource = ViewData["Favorites"];
            FavoritesRepeater.DataBind();
        }
    }
}
