using System;
using System.Net;
using System.IO;

namespace LuckyArmory.Lib.Fetcher {
    public class XmlFetcher {

        protected XmlFetcher() { }

        protected static string getXmlFromArmory(string requestUri) {
            HttpWebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            try {
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

    }
}
