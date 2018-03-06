using MKCommander.Logic.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Queue;

namespace MKCommander.Logic.Services.Clients
{
    public class SrvClient : SrvBase
    {
        #region Constructors

        public SrvClient()
        {
            this.connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, "192.168.60.160", "admin", "123qwe.");
        }
        #endregion

        #region PublicMethods

        public List<QueueSimple> GetClientsAll()
        {
            return this.connection.LoadAll<QueueSimple>().Where(x=>!x.Disabled).ToList();
        }
        #endregion
    }
}
