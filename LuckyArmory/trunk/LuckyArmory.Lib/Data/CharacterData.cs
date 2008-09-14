using System;
using System.IO;
using System.Xml.Linq;
using LuckyArmory.Lib.Fetcher;
using LuckyArmory.Lib.Data.Type;
using LuckyArmory.Lib.Handlers;
using System.Collections.Generic;

namespace LuckyArmory.Lib.Data {

    public class CharacterData {

        #region Constructors

        public CharacterData(string realm, string name) : this(realm, name, Source.Cache) { }

        public CharacterData(string realm, string name, Source source) {
            string xml;

            if (source == Source.Cache && CacheHandler.HasCharacterDataCache(realm, name)) {
                xml = CacheHandler.GetCharacterDataXmlFromCache(realm, name);
                CacheDate = CacheHandler.GetCharacterDataCacheDate(realm, name);
            } else {
                xml = ArmoryFetcher.GetArmoryXml(name, realm);
                CacheHandler.SaveCharacterDataXmlToCache(realm, name, xml);
            }

            loadInfo(xml);
        }

        private void loadInfo(string xml) {
            this.Xml = xml;

            TextReader reader = new StringReader(xml);
            XDocument charSheet = XDocument.Load(reader);

            XElement characterInfo = charSheet.Element("page").Element("characterInfo");

            if (characterInfo.Attribute("errCode") != null &&
                characterInfo.Attribute("errCode").Value.Length > 0) {
                HasError = true;
                ErrorText = "Couldn't Find Character";
            }

            if (HasError == false) {
                XElement characterTab = characterInfo.Element("characterTab");

                getGeneralCharacterInfo(characterInfo);

                getTalents(characterTab);
                getBars(characterTab);
                getBaseStats(characterTab);
                getMeleeStats(characterTab);
                getRangedStats(characterTab);
                getSpellStats(characterTab);
                getDefenses(characterTab);
                getResistances(characterTab);

                getItems(characterTab);

                //getProfessions(characterInfo);
            }
        }

        private void getGeneralCharacterInfo(XElement characterInfo) {
            XElement character = characterInfo.Element("character");

            General.Name = character.Attribute("name").Value;
            General.Class = character.Attribute("class").Value;
            General.ClassId = character.Attribute("classId").Value;
            General.Level = character.Attribute("level").Value;
            General.Battlegroup = character.Attribute("battleGroup").Value;
            General.Faction = character.Attribute("faction").Value;
            General.Gender = character.Attribute("gender").Value;
            General.GenderId = character.Attribute("genderId").Value;
            General.GuildName = character.Attribute("guildName").Value;
            General.Race = character.Attribute("race").Value;
            General.RaceId = character.Attribute("raceId").Value;
            General.Realm = character.Attribute("realm").Value;
        }

        private void getTalents(XElement characterTab) {
            XElement talentSpec = characterTab.Element("talentSpec");

            int treeOne = Convert.ToInt32(talentSpec.Attribute("treeOne").Value);
            int treeTwo = Convert.ToInt32(talentSpec.Attribute("treeTwo").Value);
            int treeThree = Convert.ToInt32(talentSpec.Attribute("treeThree").Value);

            Talents = new TalentData(treeOne, treeTwo, treeThree, General.Class);
        }

        private void getBars(XElement characterTab) {
            XElement characterBars = characterTab.Element("characterBars");

            Bars.Health = characterBars.Element("health").Attribute("effective").Value;
            Bars.PowerBar = characterBars.Element("secondBar").Attribute("effective").Value;
            Bars.PowerBarType = characterBars.Element("secondBar").Attribute("type").Value;
        }

        private void getBaseStats(XElement characterTab) {
            XElement baseStats = characterTab.Element("baseStats");

            BaseStats.StrengthBase = Convert.ToInt32(baseStats.Element("strength").Attribute("base").Value);
            BaseStats.Strength = Convert.ToInt32(baseStats.Element("strength").Attribute("effective").Value);

            BaseStats.AgilityBase = Convert.ToInt32(baseStats.Element("agility").Attribute("base").Value);
            BaseStats.Agility = Convert.ToInt32(baseStats.Element("agility").Attribute("effective").Value);

            BaseStats.StaminaBase = Convert.ToInt32(baseStats.Element("stamina").Attribute("base").Value);
            BaseStats.Stamina = Convert.ToInt32(baseStats.Element("stamina").Attribute("effective").Value);

            BaseStats.IntellectBase = Convert.ToInt32(baseStats.Element("intellect").Attribute("base").Value);
            BaseStats.Intellect = Convert.ToInt32(baseStats.Element("intellect").Attribute("effective").Value);

            BaseStats.SpiritBase = Convert.ToInt32(baseStats.Element("spirit").Attribute("base").Value);
            BaseStats.Spirit = Convert.ToInt32(baseStats.Element("spirit").Attribute("effective").Value);

            BaseStats.ArmorBase = Convert.ToInt32(baseStats.Element("armor").Attribute("base").Value);
            BaseStats.Armor = Convert.ToInt32(baseStats.Element("armor").Attribute("effective").Value);
        }

        private void getMeleeStats(XElement characterTab) {
            XElement stats = characterTab.Element("melee");

            Melee.MainHandDps = Convert.ToDouble(stats.Element("mainHandDamage").Attribute("dps").Value);
            Melee.MainHandMax = Convert.ToInt32(stats.Element("mainHandDamage").Attribute("max").Value);
            Melee.MainHandMin = Convert.ToInt32(stats.Element("mainHandDamage").Attribute("min").Value);
            Melee.MainHandSpeed = Convert.ToDouble(stats.Element("mainHandDamage").Attribute("speed").Value);

            Melee.OffHandDps = Convert.ToDouble(stats.Element("offHandDamage").Attribute("dps").Value);
            Melee.OffHandMax = Convert.ToInt32(stats.Element("offHandDamage").Attribute("max").Value);
            Melee.OffHandMin = Convert.ToInt32(stats.Element("offHandDamage").Attribute("min").Value);
            Melee.OffHandSpeed = Convert.ToDouble(stats.Element("offHandDamage").Attribute("speed").Value);

            Melee.PowerBase = Convert.ToInt32(stats.Element("power").Attribute("base").Value);
            Melee.PowerEffective = Convert.ToInt32(stats.Element("power").Attribute("effective").Value);

            Melee.HitRating = Convert.ToInt32(stats.Element("hitRating").Attribute("value").Value);
            Melee.HitRatingPercent = Convert.ToDouble(stats.Element("hitRating").Attribute("increasedHitPercent").Value);

            Melee.CritChanceRating = Convert.ToInt32(stats.Element("critChance").Attribute("rating").Value);
            Melee.CritChancePercent = Convert.ToDouble(stats.Element("critChance").Attribute("percent").Value);

            Melee.ExpertiseRating = Convert.ToInt32(stats.Element("expertise").Attribute("rating").Value);
            Melee.ExpertisePercent = Convert.ToDouble(stats.Element("expertise").Attribute("percent").Value);
        }

        private void getRangedStats(XElement characterTab) {
            XElement stats = characterTab.Element("ranged");

            Ranged.WeaponDps = Convert.ToDouble(stats.Element("damage").Attribute("dps").Value);
            Ranged.WeaponMax = Convert.ToInt32(stats.Element("damage").Attribute("max").Value);
            Ranged.WeaponMin = Convert.ToInt32(stats.Element("damage").Attribute("min").Value);
            Ranged.WeaponSpeed = Convert.ToDouble(stats.Element("damage").Attribute("speed").Value);

            Ranged.PowerBase = Convert.ToInt32(stats.Element("power").Attribute("base").Value);
            Ranged.PowerEffective = Convert.ToInt32(stats.Element("power").Attribute("effective").Value);

            Ranged.HitRating = Convert.ToInt32(stats.Element("hitRating").Attribute("value").Value);
            Ranged.HitRatingPercent = Convert.ToDouble(stats.Element("hitRating").Attribute("increasedHitPercent").Value);

            Ranged.CritChanceRating = Convert.ToInt32(stats.Element("critChance").Attribute("rating").Value);
            Ranged.CritChancePercent = Convert.ToDouble(stats.Element("critChance").Attribute("percent").Value);
        }

        private void getSpellStats(XElement characterTab) {
            XElement stats = characterTab.Element("spell");
            XElement bonusDamage = stats.Element("bonusDamage");
            XElement critChance = stats.Element("critChance");

            Spell.BonusDamageArcane = Convert.ToInt32(bonusDamage.Element("arcane").Attribute("value").Value);
            Spell.BonusDamageFire = Convert.ToInt32(bonusDamage.Element("fire").Attribute("value").Value);
            Spell.BonusDamageFrost = Convert.ToInt32(bonusDamage.Element("frost").Attribute("value").Value);
            Spell.BonusDamageHoly = Convert.ToInt32(bonusDamage.Element("holy").Attribute("value").Value);
            Spell.BonusDamageNature = Convert.ToInt32(bonusDamage.Element("nature").Attribute("value").Value);
            Spell.BonusDamageShadow = Convert.ToInt32(bonusDamage.Element("shadow").Attribute("value").Value);

            Spell.BonusHealing = Convert.ToInt32(stats.Element("bonusHealing").Attribute("value").Value);

            Spell.HitRating = Convert.ToInt32(stats.Element("hitRating").Attribute("value").Value);
            Spell.HitRatingPercent = Convert.ToDouble(stats.Element("hitRating").Attribute("increasedHitPercent").Value);

            Spell.CritChanceRating = Convert.ToInt32(critChance.Attribute("rating").Value);
            Spell.CritChancePercentArcane = Convert.ToDouble(critChance.Element("arcane").Attribute("percent").Value);
            Spell.CritChancePercentFire = Convert.ToDouble(critChance.Element("fire").Attribute("percent").Value);
            Spell.CritChancePercentFrost = Convert.ToDouble(critChance.Element("frost").Attribute("percent").Value);
            Spell.CritChancePercentHoly = Convert.ToDouble(critChance.Element("holy").Attribute("percent").Value);
            Spell.CritChancePercentNature = Convert.ToDouble(critChance.Element("nature").Attribute("percent").Value);
            Spell.CritChancePercentShadow = Convert.ToDouble(critChance.Element("shadow").Attribute("percent").Value);

            Spell.PenetrationRating = Convert.ToInt32(stats.Element("penetration").Attribute("value").Value);

            Spell.ManaRegenCasting = Convert.ToDouble(stats.Element("manaRegen").Attribute("casting").Value);
            Spell.ManaRegenNotCasting = Convert.ToDouble(stats.Element("manaRegen").Attribute("notCasting").Value);
        }

        private void getDefenses(XElement characterTab) {
            XElement stats = characterTab.Element("defenses");

            Defense.ArmorEffective = Convert.ToInt32(stats.Element("armor").Attribute("effective").Value);
            Defense.ArmorPercent = Convert.ToDouble(stats.Element("armor").Attribute("percent").Value);

            Defense.Defense = Convert.ToDouble(stats.Element("defense").Attribute("value").Value);
            Defense.DefenseIncreasePercent = Convert.ToDouble(stats.Element("defense").Attribute("increasePercent").Value);
            Defense.DefenseDecreasePercent = Convert.ToDouble(stats.Element("defense").Attribute("decreasePercent").Value);

            Defense.DodgeRating = Convert.ToInt32(stats.Element("dodge").Attribute("rating").Value);
            Defense.DodgePercent = Convert.ToDouble(stats.Element("dodge").Attribute("percent").Value);

            Defense.DodgePercent = Convert.ToInt32(stats.Element("parry").Attribute("rating").Value);
            Defense.ParryPercent = Convert.ToDouble(stats.Element("parry").Attribute("percent").Value);

            Defense.BlockRating = Convert.ToInt32(stats.Element("block").Attribute("rating").Value);
            Defense.BlockPercent = Convert.ToDouble(stats.Element("block").Attribute("percent").Value);

            Defense.ResilienceRating = Convert.ToDouble(stats.Element("resilience").Attribute("value").Value);
            Defense.ResilienceDamagePercent = Convert.ToDouble(stats.Element("resilience").Attribute("damagePercent").Value);
            Defense.ResilienceHitPercent = Convert.ToDouble(stats.Element("resilience").Attribute("hitPercent").Value);
        }

        private void getResistances(XElement characterTab) {
            XElement resistances = characterTab.Element("resistances");

            Resistances.Arcane = Convert.ToInt32(resistances.Element("arcane").Attribute("value").Value);
            Resistances.Fire = Convert.ToInt32(resistances.Element("fire").Attribute("value").Value);
            Resistances.Frost = Convert.ToInt32(resistances.Element("frost").Attribute("value").Value);
            Resistances.Holy = Convert.ToInt32(resistances.Element("holy").Attribute("value").Value);
            Resistances.Nature = Convert.ToInt32(resistances.Element("nature").Attribute("value").Value);
            Resistances.Shadow = Convert.ToInt32(resistances.Element("shadow").Attribute("value").Value);
        }

        private void getItems(XElement characterTab) {
            IEnumerable<XElement> items = characterTab.Element("items").Elements("item");

            foreach (XElement item in items) {
                ItemData newItem = new ItemData();

                newItem.Id = Convert.ToInt32(item.Attribute("id").Value);
                newItem.Icon = item.Attribute("icon").Value;
                newItem.Slot = Convert.ToInt32(item.Attribute("slot").Value);
                newItem.EnchantId = Convert.ToInt32(item.Attribute("permanentenchant").Value);
                newItem.Gem0Id = Convert.ToInt32(item.Attribute("gem0Id").Value);
                newItem.Gem1Id = Convert.ToInt32(item.Attribute("gem1Id").Value);
                newItem.Gem2Id = Convert.ToInt32(item.Attribute("gem2Id").Value);

                Gear.Add(newItem);
            }
        }

        private static void getProfessions(XElement characterInfo) {
            XElement characterTab = characterInfo.Element("characterTab");
            XElement profs = characterTab.Element("professions");

            foreach (XElement skill in profs.Elements("skill")) {
                // TODO: NYI
            }
        }

        #endregion Constructors

        #region Properties & Fields

        public string Xml { get; set; }

        public bool HasError { get; set; }

        public string ErrorText { get; set; }

        public GeneralData General = new GeneralData();
        public BarsData Bars = new BarsData();
        public TalentData Talents;

        public List<ItemData> Gear = new List<ItemData>();

        public BaseStatsData BaseStats = new BaseStatsData();
        public MeleeData Melee = new MeleeData();
        public RangedData Ranged = new RangedData();
        public SpellData Spell = new SpellData();
        public DefensesData Defense = new DefensesData();

        public ResistancesData Resistances = new ResistancesData();

        public DateTime CacheDate = DateTime.Now;

        #endregion Properties & Fields

        #region CharacterData Source

        public enum Source { 
            Armory,
            Cache
        }

        #endregion CharacterData Source

    }
}