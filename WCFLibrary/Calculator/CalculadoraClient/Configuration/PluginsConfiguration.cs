using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClient.Configuration
{
    public class PluginsConfiguration : ConfigurationSection
    {

        public static PluginsConfiguration GetConfig()
        {
            try
            {
                var section = (PluginsConfiguration)ConfigurationManager.GetSection("PluginsConfiguration");
                return section ?? new PluginsConfiguration();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private static ConfigurationPropertyCollection properties;
        private static ConfigurationProperty propPlugins;

        static PluginsConfiguration()
        {
            propPlugins = new ConfigurationProperty(null, typeof(PluginsElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            properties = new ConfigurationPropertyCollection { propPlugins };
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return properties;
            }
        }

        public PluginsElementCollection Plugins
        {
            get
            {
                return this[propPlugins] as PluginsElementCollection;
            }
        }
    }

    public class PluginsElementCollection : ConfigurationElementCollection
    {
        public PluginsElementCollection()
        {
            properties = new ConfigurationPropertyCollection();
        }

        private static ConfigurationPropertyCollection properties;

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return properties;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "use";
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var elm = element as PluginsElement;
            if (elm == null) throw new ArgumentNullException();
            return elm.AssemblyName;
        }
    }

    public class PluginsElement : ConfigurationElement
    {
        private static ConfigurationPropertyCollection properties;
        private static ConfigurationProperty propAssembly;

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return properties;
            }
        }

        public PluginsElement()
        {
            propAssembly = new ConfigurationProperty("assembly", typeof(string),
                                                          null,
                                                          ConfigurationPropertyOptions.IsKey);
            properties = new ConfigurationPropertyCollection { propAssembly };
        }

        public PluginsElement(string assemblyName)
            : this()
        {
            AssemblyName = assemblyName;
        }

        public string AssemblyName
        {
            get
            {
                return this[propAssembly] as string;
            }
            set
            {
                this[propAssembly] = value;
            }
        }
    }
}
