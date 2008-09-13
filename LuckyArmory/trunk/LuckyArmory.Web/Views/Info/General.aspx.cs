using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyArmory.Lib.Data;

namespace LuckyArmory.Web.Views.Info {

    public partial class General : ViewPage {

        protected void Page_Load(object sender, EventArgs e) {
            BaseStatsRepeater.DataSource = ViewData["BaseStats"];
            BaseStatsRepeater.DataBind();

            MeleeRepeater.DataSource = ViewData["Melee"];
            MeleeRepeater.DataBind();

            RangedRepeater.DataSource = ViewData["Ranged"];
            RangedRepeater.DataBind();

            SpellRepeater.DataSource = ViewData["Spell"];
            SpellRepeater.DataBind();

            DefensesRepeater.DataSource = ViewData["Defenses"];
            DefensesRepeater.DataBind();

            ResistancesRepeater.DataSource = ViewData["Resistances"];
            ResistancesRepeater.DataBind();

            data = (CharacterData)ViewData["Data"];
        }

        protected CharacterData data;

    }
}
