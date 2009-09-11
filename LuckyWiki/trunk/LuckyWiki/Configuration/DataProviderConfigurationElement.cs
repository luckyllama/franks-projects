using System;
using System.Configuration;
using System.Reflection;
using LuckyWiki.Data;

namespace LuckyWiki.Configuration {
    public class DataProviderConfigurationElement : ConfigurationElement {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name {
            get {
                return (string)this["name"];
            }
            set {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type {
            get {
                return (string)this["type"];
            }
            set {
                this["type"] = value;
            }
        }

        [ConfigurationProperty("connectionStringName", IsRequired = true)]
        public string ConnectionStringName {
            get {
                return (string)this["connectionStringName"];
            }
            set {
                this["connectionStringName"] = value;
            }
        }

        public ILuckyWikiDataProvider GetInstance() {
            string[] typeParts = this.Type.Split(',');
            string typeName = Assembly.CreateQualifiedName(typeParts[1].Trim(), typeParts[0].Trim());
            Type type = System.Type.GetType(typeName, true);

            return (ILuckyWikiDataProvider) Activator.CreateInstance(type, new object[] {
                                             ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString
                                         });
        }
    }

}
