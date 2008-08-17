using System;
using iWoWArm.Data;
using iWoWArm.Handlers;

public partial class GeneralInfo : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        CharacterData data = new CharacterData(RequestRealm, RequestName);

        if (data.HasError) {
            Response.Redirect("Default.aspx?error=noChar");
        }

        if (RequestFavorite) {
            FavoritesHandler.SaveNewFavorite(RequestRealm, RequestName);
        }

        this.data = data;
    }

    protected CharacterData data;

    #region Page Params

    private string RequestName {
        get {
            return Request.QueryString["n"];
        }
    }

    private string RequestRealm {
        get { return Request.QueryString["r"]; }
    }

    private bool RequestFavorite {
        get {
            string value = Request.QueryString["favorite"];
            if (value == "on") {
                return true;
            }

            return false;
        }
    }

    #endregion Page Params

}
