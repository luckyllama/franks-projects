using LuckyArmory.Lib.Handlers;
using System.Text;

namespace LuckyArmory.Lib.Fetcher {

    public class ArmoryFetcher : XmlFetcher {

        private ArmoryFetcher() { }

        public static string GetArmoryXml(string name, string realm) {
            string requestUri = ApplicationSettings.ArmorySearchUri(getCleanRealmName(realm), name);
            string xml = getXmlFromArmory(requestUri);

            return xml;
        }

        private static string getCleanRealmName(string realm) {
            string cleanServer = realm;

            cleanServer = cleanServer.Replace(' ', '+');

            return cleanServer;
        }

    }
}