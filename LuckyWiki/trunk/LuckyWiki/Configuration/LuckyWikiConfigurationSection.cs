using System.Configuration;

namespace LuckyWiki.Configuration {
    public class LuckyWikiConfigurationSection : ConfigurationSection {

        [ConfigurationProperty("dataProvider")]
        public DataProviderConfigurationElement DataProvider {
            get { return this["dataProvider"] as DataProviderConfigurationElement; }
            set { this["dataProvider"] = value; }
        }

        [
        ConfigurationProperty("Articles", IsDefaultCollection=false),
        ConfigurationCollection(typeof(EmailConfigurationCollection))
        ]
        public EmailConfigurationCollection Emails {
            get { return this["emails"] as EmailConfigurationCollection; }
            set { this["emails"] = value; }
        }
    }
}
