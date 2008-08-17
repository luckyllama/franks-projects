using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iWoWArm.Handlers;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Request.QueryString["error"] == "noChar") {
            ErrorDisplay.Text = "Couldn't Find Character";
        }

        displayFavoriteCharacters();
    }

    private void displayFavoriteCharacters() {
        IDictionary<string, string> favorites = FavoritesHandler.GetFavorites();

        if (favorites.Count == 0) {
            FavoritesDisplay.Text = "<li>No Favorites</li>";
        } else {
            foreach (string key in favorites.Keys) {
                FavoritesDisplay.Text += "<li><a href=\"GeneralInfo.aspx?" + favorites[key] + "\">" + key + "</a></li>";
            }
        }

    }
}
