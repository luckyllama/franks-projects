using LuckyArmory.Lib.Handlers;
using System.Net;
using System.IO;
using System.Text;

namespace LuckyArmory.Lib.Armory {

    public class ArmoryFetcher {

        private ArmoryFetcher() { }

        public static string GetArmoryXml(string name, string realm) {
            string xml = getXmlFromArmory(name, realm);

            return xml;
        }

        #region Armory Functions

        private static string getXmlFromArmory(string name, string realm) {
            HttpWebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            try {
                string requestUri = ApplicationSettings.ArmorySearchUri(getCleanRealmName(realm), name);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

                request.ContentType = ApplicationSettings.ArmoryContentType;
                request.UserAgent = ApplicationSettings.ArmoryUserAgent;

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                reader = new StreamReader(stream);

                return reader.ReadToEnd();
            } finally {
                try {
                    response.Close();
                    stream.Close();
                    reader.Close();
                } catch {
                    throw;
                }
            }
        }

        private static string getCleanRealmName(string realm) {
            string cleanServer = realm;

            cleanServer = cleanServer.Replace(' ', '+');

            return cleanServer;
        }

        #endregion Armory Functions

    }
}