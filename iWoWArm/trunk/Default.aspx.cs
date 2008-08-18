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

        dataBindFavoriteCharacters();
    }

    #region Data Bind Favorites Characters

    private void dataBindFavoriteCharacters() {
        IDictionary<string, string> favorites = FavoritesHandler.GetFavorites();

        Dictionary<string, string> repeaterData = getFavoritesRepeaterData(favorites);

        FavoritesRepeater.DataSource = repeaterData;
        FavoritesRepeater.DataBind();

    }

    private Dictionary<string, string> getFavoritesRepeaterData(IDictionary<string, string> favorites) {
        Dictionary<string, string> repeaterData = new Dictionary<string, string>();

        if (favorites.Count == 0) {
            repeaterData.Add("No Favorites", "");
        } else {
            foreach (string key in favorites.Keys) {
                repeaterData.Add(rapTextInFavoritesLink(favorites[key], key), "<a href=\"#\" class=\"DeleteIcon\"></a>");
            }
        }

        return repeaterData;
    }

    private string rapTextInFavoritesLink(string queryString, string linkText) {
        return "<a href=\"GeneralInfo.aspx?" + queryString + "\">" + linkText + "</a>";
    }

    #endregion Data Bind Favorites Characters
}
