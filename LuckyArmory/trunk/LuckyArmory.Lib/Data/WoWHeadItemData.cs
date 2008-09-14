using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuckyArmory.Lib.Handlers;
using LuckyArmory.Lib.Fetcher;
using System.IO;
using System.Xml.Linq;

namespace LuckyArmory.Lib.Data {
    public class WoWHeadItemData {

        #region Constructors

        public WoWHeadItemData(int id) : this(id, Source.Cache) { }

        public WoWHeadItemData(int id, Source source) {
            string xml;

            //if (source == Source.Cache && CacheHandler.HasCharacterDataCache(id)) {
            //    xml = CacheHandler.GetCharacterDataXmlFromCache(realm, name);
            //    CacheDate = CacheHandler.GetCharacterDataCacheDate(realm, name);
            //} else {
                xml = WoWHeadItemFetcher.GetItemXml(id);
            //    CacheHandler.SaveCharacterDataXmlToCache(realm, name, xml);
            //}

            loadInfo(xml, id);
        }

        private void loadInfo(string xml, int id) {
            this.Xml = xml;
            this.Id = id;

            TextReader reader = new StringReader(xml);
            XDocument charSheet = XDocument.Load(reader);

            XElement item = charSheet.Element("wowhead").Element("item");
            
            Name = item.Element("name").Value;
            Level = Convert.ToInt32(item.Element("level").Value);
            Quality = item.Element("quality").Value;
            Icon = item.Element("icon").Value;
            HtmlTooltip = item.Element("htmlTooltip").Value;
            Link = item.Element("link").Value;
            
        }

        #endregion Constructors

        #region Proporties & Fields

        public string Xml { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Quality { get; set; }

        public string Icon { get; set; }

        public string HtmlTooltip { get; set; }

        public string Link { get; set; }

        #endregion Proporties & Fields

        #region ItemData Source

        public enum Source { 
            Cache,
            WoWHead
        }

        #endregion ItemData Source
    }
}
