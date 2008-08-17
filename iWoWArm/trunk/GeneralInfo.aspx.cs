using System;
using System.Collections.Generic;
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

        dataBindMeleeRepeater();
        dataBindRangedRepeater();
        dataBindSpellRepeater();
        dataBindDefensesRepeater();
        dataBindResistancesRepeater();
    }

    #region Melee Repeater 

    private void dataBindMeleeRepeater() {
        Dictionary<string, string> meleeData = getMeleeRepeaterData();

        MeleeRepeater.DataSource = meleeData;
        MeleeRepeater.DataBind();
    }

    private Dictionary<string, string> getMeleeRepeaterData() {
        Dictionary<string, string> meleeData = new Dictionary<string, string>();

        meleeData.Add("Main Hand",
            rapMainStatInHtml(data.Melee.MainHandDps + "dps ") 
            + "(" + data.Melee.MainHandMin + "-" + data.Melee.MainHandMax + ") " + data.Melee.MainHandSpeed + " speed");

        if (HasOffHandWeapon) {
            meleeData.Add("Off Hand",
                rapMainStatInHtml(data.Melee.OffHandDps + "dps ") 
                + "(" + data.Melee.OffHandMin + "-" + data.Melee.OffHandMax + ") " + data.Melee.OffHandSpeed + " speed");
        }

        meleeData.Add("Attack Power",
            rapMainStatInHtml(data.Melee.PowerEffective.ToString()) + " (" + data.Melee.PowerBase + " + " + 
            (data.Melee.PowerEffective - data.Melee.PowerBase) + ")");

        meleeData.Add("Hit Rating",
            data.Melee.HitRating + " (" + rapMainStatInHtml(data.Melee.HitRatingPercent + "%") + ")");

        meleeData.Add("Crit Chance",
            data.Melee.CritChanceRating + " (" + rapMainStatInHtml(data.Melee.CritChancePercent + "%") + ")");

        meleeData.Add("Expertise",
            data.Melee.ExpertiseRating + " (" + rapMainStatInHtml(data.Melee.ExpertisePercent + "%") + ")");

        return meleeData;
    }

    public bool HasOffHandWeapon {
        get {
            if (Convert.ToInt32(data.Melee.OffHandMin) > 0) {
                return true;
            }
            return false;
        }
    }

    #endregion Melee Repeater

    #region Ranged Repeater 

    private void dataBindRangedRepeater() {
        Dictionary<string, string> rangedData = getRangedRepeaterData();

        RangedRepeater.DataSource = rangedData;
        RangedRepeater.DataBind();
    }

    private Dictionary<string, string> getRangedRepeaterData() {
        Dictionary<string, string> rangedData = new Dictionary<string, string>();

        rangedData.Add("Weapon",
            rapMainStatInHtml(data.Ranged.WeaponDps + "dps ") + "(" + data.Ranged.WeaponMin + "-" + data.Ranged.WeaponMax + ") " +
                    data.Ranged.WeaponSpeed + " speed");

        rangedData.Add("Attack Power",
            rapMainStatInHtml(data.Ranged.PowerEffective.ToString()) + " (" + data.Ranged.PowerBase + " + " +
            (Convert.ToInt32(data.Ranged.PowerEffective) - Convert.ToInt32(data.Ranged.PowerBase)) + ")");

        rangedData.Add("Hit Rating",
            data.Ranged.HitRating + " (" + rapMainStatInHtml(data.Ranged.HitRatingPercent + "%") + ")");

        rangedData.Add("Crit Chance",
            data.Ranged.CritChanceRating + " (" + rapMainStatInHtml(data.Ranged.CritChancePercent + "%") + ")");

        return rangedData;
    }

    protected bool HasRanged {
        get {
            if (Convert.ToInt32(data.Ranged.WeaponMax) > 0) {
                return true;
            }
            return false;
        }
    }

    #endregion Ranged Repeater

    #region Spell Repeater

    private void dataBindSpellRepeater() {
        Dictionary<string, string> rangedData = getSpellRepeaterData();

        SpellRepeater.DataSource = rangedData;
        SpellRepeater.DataBind();
    }

    private Dictionary<string, string> getSpellRepeaterData() {
        Dictionary<string, string> spellData = new Dictionary<string, string>();

        string bonusDamage = rapMainStatInHtml(data.Spell.BonusDamageMode.ToString());
        if (data.Spell.BonusDamageArcane != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Arcane", data.Spell.BonusDamageArcane.ToString());
        }
        if (data.Spell.BonusDamageFire != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Fire", data.Spell.BonusDamageFire.ToString());
        }
        if (data.Spell.BonusDamageFrost != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Frost", data.Spell.BonusDamageFrost.ToString());
        }
        if (data.Spell.BonusDamageHoly != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Holy", data.Spell.BonusDamageHoly.ToString());
        }
        if (data.Spell.BonusDamageNature != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Nature", data.Spell.BonusDamageNature.ToString());
        }
        if (data.Spell.BonusDamageShadow != data.Spell.BonusDamageMode) {
            bonusDamage += " / " + rapMagicSchoolInHtml("Shadow", data.Spell.BonusDamageShadow.ToString());
        }

        spellData.Add("Bonus Damage", bonusDamage);

        spellData.Add("Bonus Healing", data.Spell.BonusHealing.ToString());

        spellData.Add("Hit Rating",
            data.Spell.HitRating + " (" + rapMainStatInHtml(data.Spell.HitRatingPercent + "%") + ")");

        string critChance = data.Spell.CritChanceRating 
            + " (" + rapMainStatInHtml(data.Spell.CritChancePercentageMode + "%") + ")";
        if (data.Spell.CritChancePercentArcane != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Arcane", data.Spell.BonusDamageArcane.ToString());
        }
        if (data.Spell.CritChancePercentFire != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Fire", data.Spell.CritChancePercentFire.ToString());
        }
        if (data.Spell.CritChancePercentFrost != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Frost", data.Spell.CritChancePercentFrost.ToString());
        }
        if (data.Spell.CritChancePercentHoly != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Holy", data.Spell.CritChancePercentHoly.ToString());
        }
        if (data.Spell.CritChancePercentNature != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Nature", data.Spell.CritChancePercentNature.ToString());
        }
        if (data.Spell.CritChancePercentShadow != data.Spell.CritChancePercentageMode) {
            critChance += " / " + rapMagicSchoolInHtml("Shadow", data.Spell.CritChancePercentShadow.ToString());
        }

        spellData.Add("Crit Chance", critChance);

        spellData.Add("Penetration", data.Spell.PenetrationRating.ToString());

        spellData.Add("Mana Regen", data.Spell.ManaRegenCasting + " / " + data.Spell.ManaRegenNotCasting);

        return spellData;
    }

    protected bool HasSpell {
        get { 
            int totalSpellStats = data.Spell.BonusDamageArcane + data.Spell.BonusDamageFire
                + data.Spell.BonusDamageFrost + data.Spell.BonusDamageHoly + data.Spell.BonusDamageNature
                + data.Spell.BonusDamageShadow + data.Spell.BonusHealing;
            if (totalSpellStats > 0) {
                return true;
            }
            return false;
        }
    }

    #endregion Spell Repeater

    #region Defenses Repeater

    private void dataBindDefensesRepeater() {
        Dictionary<string, string> defensesData = getDefensesRepeaterData();

        DefensesRepeater.DataSource = defensesData;
        DefensesRepeater.DataBind();
    }

    private Dictionary<string, string> getDefensesRepeaterData() {
        Dictionary<string, string> defensesData = new Dictionary<string, string>();


        return defensesData;
    }

    #endregion Defenses Repeater

    #region Resistances Repeater

    private void dataBindResistancesRepeater() {
        Dictionary<string, string> resistancesData = getResistancesRepeaterData();

        ResistancesRepeater.DataSource = resistancesData;
        ResistancesRepeater.DataBind();
    }

    private Dictionary<string, string> getResistancesRepeaterData() {
        Dictionary<string, string> resistancesData = new Dictionary<string, string>();

        resistancesData.Add("Arcane", rapMagicSchoolInHtml("Arcane", data.Resistances.Arcane.ToString()));
        resistancesData.Add("Fire", rapMagicSchoolInHtml("Fire", data.Resistances.Fire.ToString()));
        resistancesData.Add("Frost", rapMagicSchoolInHtml("Frost", data.Resistances.Frost.ToString()));
        resistancesData.Add("Holy", rapMagicSchoolInHtml("Holy", data.Resistances.Holy.ToString()));
        resistancesData.Add("Nature", rapMagicSchoolInHtml("Nature", data.Resistances.Nature.ToString()));
        resistancesData.Add("Shadow", rapMagicSchoolInHtml("Shadow", data.Resistances.Shadow.ToString()));

        return resistancesData;
    }

    #endregion Resistances Repeater

    protected CharacterData data;

    #region Helpful Methods

    private string rapMagicSchoolInHtml(string school, string value) {
        return "<span class=\"" + school + "\">" + value + "</span>";
    }

    private string rapMainStatInHtml(string value) {
        return "<span class=\"MainStat\">" + value + "</span>";
    }

    #endregion Helpful Methods

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
