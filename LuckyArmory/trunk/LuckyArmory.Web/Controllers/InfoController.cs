using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyArmory.Lib.Handlers;
using LuckyArmory.Lib.Data;
using System.Web.Script.Serialization;
using LuckyArmory.Lib.Fetcher;

namespace LuckyArmory.Web.Controllers {

    public class InfoController : Controller {

        public ActionResult General(string realm, string name, string favorite) {
            ViewData["Title"] = "General Info";

            if (string.IsNullOrEmpty(realm) || string.IsNullOrEmpty(name)) {
                return RedirectToAction("Index", "Home");
            }

            CharacterData data = new CharacterData(realm, name);

            if (data.HasError) {
                return RedirectToAction("Index", "Home", new { errorMessage = "noChar" });
            }

            if (favorite == "Save") {
                FavoritesHandler.SaveNewFavorite(realm, name);
            }

            ViewData["BaseStats"] = getBaseStatsRepeaterData(data);
            ViewData["Melee"] = getMeleeRepeaterData(data);
            ViewData["Ranged"] = getRangedRepeaterData(data);
            ViewData["Spell"] = getSpellRepeaterData(data);
            ViewData["Defenses"] = getDefensesRepeaterData(data);
            ViewData["Resistances"] = getResistancesRepeaterData(data);

            ViewData["Data"] = data;

            return View();
        }

        #region Create General Repeater Data

        #region Base Stats Repeater

        private Dictionary<string, string> getBaseStatsRepeaterData(CharacterData data) {
            Dictionary<string, string> baseStatsData = new Dictionary<string, string>();

            baseStatsData.Add("Strength",
                rapMainStatInHtml(data.BaseStats.Strength.ToString()) + " (" + data.BaseStats.StrengthBase + " + " +
                (data.BaseStats.Strength - data.BaseStats.StrengthBase) + ")");

            baseStatsData.Add("Agility",
                rapMainStatInHtml(data.BaseStats.Agility.ToString()) + " (" + data.BaseStats.AgilityBase + " + " +
                (data.BaseStats.Agility - data.BaseStats.AgilityBase) + ")");

            baseStatsData.Add("Stamina",
                rapMainStatInHtml(data.BaseStats.Stamina.ToString()) + " (" + data.BaseStats.StaminaBase + " + " +
                (data.BaseStats.Stamina - data.BaseStats.StaminaBase) + ")");

            baseStatsData.Add("Intellect",
                rapMainStatInHtml(data.BaseStats.Intellect.ToString()) + " (" + data.BaseStats.IntellectBase + " + " +
                (data.BaseStats.Intellect - data.BaseStats.IntellectBase) + ")");

            baseStatsData.Add("Spirit",
                rapMainStatInHtml(data.BaseStats.Spirit.ToString()) + " (" + data.BaseStats.SpiritBase + " + " +
                (data.BaseStats.Spirit - data.BaseStats.SpiritBase) + ")");

            baseStatsData.Add("Armor", data.BaseStats.Armor.ToString());

            return baseStatsData;
        }

        #endregion Base Stats Repeater

        #region Melee Repeater

        private Dictionary<string, string> getMeleeRepeaterData(CharacterData data) {
            Dictionary<string, string> meleeData = new Dictionary<string, string>();

            meleeData.Add("Main Hand",
                rapMainStatInHtml(data.Melee.MainHandDps + "dps ")
                + "(" + data.Melee.MainHandMin + "-" + data.Melee.MainHandMax + ") " + data.Melee.MainHandSpeed + " speed");

            if (data.Melee.HasOffHandWeapon) {
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

        #endregion Melee Repeater

        #region Ranged Repeater

        private Dictionary<string, string> getRangedRepeaterData(CharacterData data) {
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

        #endregion Ranged Repeater

        #region Spell Repeater

        private Dictionary<string, string> getSpellRepeaterData(CharacterData data) {
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

        #endregion Spell Repeater

        #region Defenses Repeater

        private Dictionary<string, string> getDefensesRepeaterData(CharacterData data) {
            Dictionary<string, string> defensesData = new Dictionary<string, string>();

            defensesData.Add("Armor",
                rapMainStatInHtml(data.Defense.ArmorEffective.ToString()) + " (" + data.Defense.ArmorPercent + "%)");

            defensesData.Add("Defense",
                rapMainStatInHtml(data.Defense.Defense.ToString()) + " (-" + data.Defense.DefenseDecreasePercent + "% / +"
                + data.Defense.DefenseIncreasePercent + "%)");

            defensesData.Add("Dodge",
                data.Defense.DodgeRating + " (" + rapMainStatInHtml(data.Defense.DodgePercent + "%") + ")");

            defensesData.Add("Parry",
                data.Defense.ParryRating + " (" + rapMainStatInHtml(data.Defense.ParryPercent + "%") + ")");

            defensesData.Add("Block",
                data.Defense.BlockRating + " (" + rapMainStatInHtml(data.Defense.BlockPercent + "%") + ")");

            defensesData.Add("Resilience",
                rapMainStatInHtml(data.Defense.ResilienceRating.ToString()) + " (" + data.Defense.ResilienceHitPercent
                + "% / " + data.Defense.ResilienceDamagePercent + "%)");

            return defensesData;
        }

        #endregion Defenses Repeater

        #region Resistances Repeater

        private Dictionary<string, string> getResistancesRepeaterData(CharacterData data) {
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

        #region Helpful Methods

        private string rapMagicSchoolInHtml(string school, string value) {
            return "<span class=\"" + school + "\">" + value + "</span>";
        }

        private string rapMainStatInHtml(string value) {
            return "<span class=\"MainStat\">" + value + "</span>";
        }

        #endregion Helpful Methods

        #endregion Create General Repeater Data

        public ActionResult Gear(string realm, string name) {
            ViewData["Title"] = "Gear";

            if (string.IsNullOrEmpty(realm) || string.IsNullOrEmpty(name)) {
                return RedirectToAction("Index", "Home");
            }

            CharacterData data = new CharacterData(realm, name, CharacterData.Source.Cache);

            if (data.HasError) {
                return RedirectToAction("Index", "Home", new { errorMessage = "noChar" });
            }

            ViewData["Gear"] = data.Gear;

            return View();
        }

        public ActionResult Item(int id) {
            WoWHeadItemData result = new WoWHeadItemData(id);
            return Json(result);
        }

    }
}
