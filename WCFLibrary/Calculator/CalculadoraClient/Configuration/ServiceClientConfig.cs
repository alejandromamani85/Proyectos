using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClient.Configuration
{
    public class ServiceClientConfig : ConfigurationSection
    {

        public static ServiceClientConfig GetConfig()
        {
            try
            {
                var section = (ServiceClientConfig)ConfigurationManager.GetSection("ServicioPrueba");
                return section ?? new ServiceClientConfig();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ConfigurationProperty("MockMode", DefaultValue = "false", IsRequired = false)]
        public bool MockMode
        {
            get { return (bool)this["MockMode"]; }
            //set { this["MockMode"] = value; }
        }

    }
}
