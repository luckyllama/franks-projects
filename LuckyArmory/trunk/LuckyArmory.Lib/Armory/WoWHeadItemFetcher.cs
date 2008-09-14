using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyArmory.Lib.Fetcher {
    public class WoWHeadItemFetcher : XmlFetcher {

        public static string GetItemXml(int id) {
            string requestUri = ApplicationSettings.WoWHeadItemXmlUri(id);
            string xml = getXmlFromArmory(requestUri);

            return xml;
        }

    }
}
