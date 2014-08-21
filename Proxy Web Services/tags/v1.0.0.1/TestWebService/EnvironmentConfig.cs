using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Linq;

namespace TestWebService
{
    public class EnvironmentConfig : ConfigurationElement
    {
        [ConfigurationProperty("EnvironmentDescription", IsRequired = true)]
        public string sEnvironmentDescription
        {
            get
            {
                return (string)this["EnvironmentDescription"];
            }
            set
            {
                this["EnvironmentDescription"] = value;
            }

        }

        [ConfigurationProperty("BaseWSURL", IsRequired = true)]
        public string sBaseWSURL
        {
            get
            {
                return (string)this["BaseWSURL"];
            }
            set
            {
                this["BaseWSURL"] = value;
            }

        }

        public string Key
        {
            get { return string.Format("{0}|{1}", sEnvironmentDescription, sBaseWSURL); }
        }
    }

    public class EnvironmentConfigCollection : ConfigurationElementCollection, IEnumerable<EnvironmentConfig>
    {
        public EnvironmentConfig this[int index]
        {
            get { return base.BaseGet(index) as EnvironmentConfig; }
            set
            {
                if (base.BaseGet(index) != null)
                { base.BaseRemoveAt(index); }
                this.BaseAdd(index, value);

            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EnvironmentConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnvironmentConfig)element).Key;
        }

        public new IEnumerator<EnvironmentConfig> GetEnumerator()
        {
            return this.OfType<EnvironmentConfig>().GetEnumerator();
        }
    }

    public class EnvironmentConfigConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("EnvironmentConfigs")]
        public EnvironmentConfigCollection EnvironmentConfigs
        {
            get { return this["EnvironmentConfigs"] as EnvironmentConfigCollection; }
        }

        public static EnvironmentConfigConfigurationSection GetConfig()
        {
            return System.Configuration.ConfigurationManager.GetSection("PBS/EnvironmentConfigCollection") as EnvironmentConfigConfigurationSection;
        }
    }
}
