using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LuckyArmory.Lib.Handlers {

    public class CacheHandler {
        private CacheHandler() {}

        public static bool HasCharacterDataCache(string realm, string name) {
            string cacheDirectory = getCacheDirectoryPath();

            string filePath = cacheDirectory + getCharacterDataCacheFilePath(realm, name);
            if (File.Exists(filePath)) {
                return true;
            }
            return false;
        }

        private static string getCharacterDataCacheFilePath(string realm, string name) {
            return realm + "/" + name + ".xml";
        }

        private static string getCacheDirectoryPath() {
            return HttpRuntime.AppDomainAppPath + ApplicationSettings.CharacterDataCacheDirectoryPath;
        }

        public static void SaveCharacterDataXmlToCache(string realm, string name, string xml) {
            string cacheDirectory = getCacheDirectoryPath();

            if (Directory.Exists(cacheDirectory + realm) == false) {
                Directory.CreateDirectory(cacheDirectory + realm);
            }

            string filePath = cacheDirectory + getCharacterDataCacheFilePath(realm, name);

            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(xml);
            writer.Close();
        }

        public static string GetCharacterDataXmlFromCache(string realm, string name) {
            string filePath = getCacheDirectoryPath() + getCharacterDataCacheFilePath(realm, name);
            
            StreamReader reader = new StreamReader(filePath);
            string xml = reader.ReadToEnd();
            reader.Close();

            return xml;
        }

        public static DateTime GetCharacterDataCacheDate(string realm, string name) {
            if (HasCharacterDataCache(realm, name)) {
                string filePath = getCacheDirectoryPath() + getCharacterDataCacheFilePath(realm, name);
                return File.GetLastWriteTime(filePath);
            } else {
                return DateTime.MinValue;
            }
        }
    }

}