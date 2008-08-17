using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using iWoWArm.WoW;
using iWoWArm.Handlers;
using iWoWArm.Armory;
using iWoWArm.Data.Type;

namespace iWoWArm.Data {

    public class CharacterData {

        #region Constructors

        public CharacterData(string realm, string name) : this(realm, name, Source.Cache) { }

        public CharacterData(string realm, string name, Source source) {
            string xml;

            if (source == Source.Cache && CacheHandler.HasCache(name, realm)) {
                xml = CacheHandler.GetXmlFromCache(name, realm);
            } else {
                xml = ArmoryFetcher.GetArmoryXml(name, realm);
                CacheHandler.SaveXmlToCache(name, realm, xml);
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
                getResistances(characterTab);

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

            BaseStats.StrengthBase = baseStats.Element("strength").Attribute("base").Value;
            BaseStats.Strength = baseStats.Element("strength").Attribute("effective").Value;

            BaseStats.AgilityBase = baseStats.Element("agility").Attribute("base").Value;
            BaseStats.Agility = baseStats.Element("agility").Attribute("effective").Value;

            BaseStats.StaminaBase = baseStats.Element("stamina").Attribute("base").Value;
            BaseStats.Stamina = baseStats.Element("stamina").Attribute("effective").Value;

            BaseStats.IntellectBase = baseStats.Element("intellect").Attribute("base").Value;
            BaseStats.Intellect = baseStats.Element("intellect").Attribute("effective").Value;

            BaseStats.SpiritBase = baseStats.Element("spirit").Attribute("base").Value;
            BaseStats.Spirit = baseStats.Element("spirit").Attribute("effective").Value;

            BaseStats.ArmorBase = baseStats.Element("armor").Attribute("base").Value;
            BaseStats.Armor = baseStats.Element("armor").Attribute("effective").Value;
        }

        private void getResistances(XElement characterTab) {
            XElement resistances = characterTab.Element("resistances");

            Resistances.Arcane = resistances.Element("arcane").Attribute("value").Value;
            Resistances.Fire = resistances.Element("fire").Attribute("value").Value;
            Resistances.Frost = resistances.Element("frost").Attribute("value").Value;
            Resistances.Holy = resistances.Element("holy").Attribute("value").Value;
            Resistances.Nature = resistances.Element("nature").Attribute("value").Value;
            Resistances.Shadow = resistances.Element("shadow").Attribute("value").Value;
        }

        private static void getProfessions(XElement characterInfo) {
            XElement characterTab = characterInfo.Element("characterTab");
            XElement profs = characterTab.Element("professions");

            foreach (XElement skill in profs.Elements("skill")) {

            }

            /* var profs = from item in profsEl.Descendants("skill")
            select new
            {
                Key = item.Attribute("key").Value,
                Name = item.Attribute("max").Value,
                Max = item.Attribute("name").Value,
                Value = item.Attribute("value").Value
            };
             * */
        }

        #endregion Constructors

        #region Properties & Fields

        public string Xml { get; set; }

        public bool HasError { get; set; }

        public string ErrorText { get; set; }

        public GeneralData General = new GeneralData();

        public BarsData Bars = new BarsData();

        public TalentData Talents;

        public BaseStatsData BaseStats = new BaseStatsData();

        public ResistancesData Resistances = new ResistancesData();

        #endregion Properties & Fields

        #region CharacterData Source

        public enum Source { 
            Armory,
            Cache
        }

        #endregion CharacterData Source

    }
}