using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClient.Configuration
{



    public class MyConfigSection : ConfigurationSection
    {
        public static MyConfigSection GetConfig()
        {
            try
            {
                MyConfigSection section = ConfigurationManager.GetSection("registerCompanies") as MyConfigSection;
                foreach (MyConfigInstanceElement e in section.Instances)
                {
                    String name = e.Name;
                    String code = e.Code;
                    //String value = e.Value;
                }
                
                return section ?? new MyConfigSection();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public MyConfigInstanceCollection Instances
        {
            get { return (MyConfigInstanceCollection)this[""]; }
            set { this[""] = value; }
        }
    }
    public class MyConfigInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyConfigInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((MyConfigInstanceElement)element).Name;
        }
    }

    public class MyConfigInstanceElement : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("code", IsRequired = true)]
        public string Code
        {
            get { return (string)base["code"]; }
            set { base["code"] = value; }
        }
    }

}
