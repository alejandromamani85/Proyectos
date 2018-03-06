using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Interface;
using tik4net.Objects.Tool;

namespace MKCommander.Logic
{
    public class ServicioTest
    {
        #region Properties

        ITikConnection connection;
        #endregion

        #region Constructors

        public ServicioTest()
        {
            this.connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, "192.168.60.160", "admin", "123qwe.");
        }
        #endregion

        #region PublicMethods

        public IEnumerable<Interface> GetInterfaces()
        {
            var interfaces = connection.LoadAll<Interface>();
            return interfaces;
        }
        
        public List<ToolPing> Ping(string address, short count = 1, short size = 64)
        {
            List<ToolPing> responseList = new List<ToolPing>();
            Exception responseException = null;
            try
            {
                ITikCommand pingCommand = connection.LoadAsync<ToolPing>(ping =>
                    responseList.Add(ping),
                    exception => responseException = exception,
                    connection.CreateParameter("address", address),
                    connection.CreateParameter("count", count.ToString()),
                    connection.CreateParameter("size", "64")
                );

                Thread.Sleep(2 * 1000);
                if (responseException != null)
                    throw responseException;
                return responseList;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

    }
}
