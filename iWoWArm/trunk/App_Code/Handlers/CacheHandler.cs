using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace iWoWArm.Handlers {

    public class CacheHandler {
        private CacheHandler() {}

        public static bool HasCache(string name, string server) {
            string cacheDirectory = getCacheDirectoryPath();

            string filePath = cacheDirectory + getCacheFilePath(name, server);
            if (File.Exists(filePath)) {
                return true;
            }
            return false;
        }

        private static string getCacheFilePath(string name, string server) {
            return server + "/" + name + ".xml";
        }

        private static string getCacheDirectoryPath() {
            return HttpRuntime.AppDomainAppPath + ApplicationSettings.CacheDirectoryPath;
        }

        public static void SaveXmlToCache(string name, string server, string xml) {
            string cacheDirectory = getCacheDirectoryPath();

            if (Directory.Exists(cacheDirectory + server) == false) {
                Directory.CreateDirectory(cacheDirectory + server);
            }

            string filePath = cacheDirectory + getCacheFilePath(name, server);

            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(xml);
            writer.Close();
        }

        public static string GetXmlFromCache(string name, string server) {
            string filePath = getCacheDirectoryPath() + getCacheFilePath(name, server);
            
            StreamReader reader = new StreamReader(filePath);
            string xml = reader.ReadToEnd();
            reader.Close();

            return xml;
        }
    }

}