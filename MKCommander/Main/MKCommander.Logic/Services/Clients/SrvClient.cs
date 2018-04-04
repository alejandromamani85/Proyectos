using MKCommander.Common.Models.Client;
using MKCommander.Logic.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Ip.Firewall;
using tik4net.Objects.Queue;

namespace MKCommander.Logic.Services.Clients
{
    public class SrvClient : SrvBase
    {
        #region PrivateAttributes

        private List<String> listHost = new List<String> { "192.168.60.50", "192.168.60.160", "192.168.60.170", "192.168.60.180" };
        //private List<String> listHost = new List<String> { "192.168.60.50", "192.168.60.160", "192.168.60.170" };
        #endregion

        #region Constructors

        public SrvClient()
        {
            //this.Connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, "192.168.60.160", "admin", "123qwe.");
        }
        #endregion

        #region PublicMethods

        public List<QueueSimple> GetClientsAll()
        {
            return this.Connection.LoadAll<QueueSimple>().Where(x => !x.Disabled).ToList();
        }

        public List<QueueSimple> GetClientsAllConnections()
        {
            var listClientAll = new List<QueueSimple>();
            object locker = new object();
            Parallel.ForEach(listHost, host =>
            {
                var listClientByRouter = default(IEnumerable<QueueSimple>);
                using (var conn = ConnectionFactory.OpenConnection(TikConnectionType.Api, host, "admin", "123qwe."))
                {
                    listClientByRouter = conn.LoadAll<QueueSimple>().Where(x => !x.Disabled).ToList();
                }
                lock (locker)
                {
                    listClientAll.AddRange(listClientByRouter);
                }
            });
            return listClientAll;
        }

        public List<ClientCustom> GetClientsAllConnectionsFull()
        {
            var listClientAll = new List<ClientCustom>();
            object locker = new object();
            Parallel.ForEach(listHost, host =>
            {
                var listClientByRouter = new List<ClientCustom>();
                using (var conn = ConnectionFactory.OpenConnection(TikConnectionType.Api, host, "admin", "123qwe."))
                {
                    listClientByRouter = conn.LoadAll<QueueSimple>().Where(x => !x.Disabled)
                        .Select(x => new ClientCustom(x.Name, x.Target, x.Comment, host))
                        .ToList();

                }
                lock (locker)
                {
                    listClientAll.AddRange(listClientByRouter);
                }
            });

            return listClientAll.OrderBy(x => x.Name).Select((x, index) => new ClientCustom(x.Name, x.Target, x.Comment, x.Host, index)).ToList();
        }

        public List<FirewallAddressList> GetClientFirewallAddresList()
        {
            var listFirewallAddressList = new List<FirewallAddressList>();
            object locker = new object();
            Parallel.ForEach(listHost, host =>
            {
                var listFirewallAddressListByRouter = new List<FirewallAddressList>();
                using (var conn = ConnectionFactory.OpenConnection(TikConnectionType.Api, host, "admin", "123qwe."))
                {
                    //listFirewallAddressListByRouter = conn.LoadList<FirewallAddressList>(conn.CreateParameter("list", "bloqueo")).ToList();
                    listFirewallAddressListByRouter = conn.LoadAll<FirewallAddressList>().Where(x => !x.Disabled).ToList();
                }
                lock (locker)
                {
                    listFirewallAddressList.AddRange(listFirewallAddressListByRouter);
                }
            });
            return listFirewallAddressList;
        }

        public List<ClientCustom> GetClientAllStatus()
        {
            var listClient = GetClientsAllConnectionsFull();
            var listFirewallAddress = GetClientFirewallAddresList();

            return listClient.Select((x, index) =>
                new ClientCustom
                (
                    name: x.Name,
                    target: x.Target,
                    comment: x.Comment,
                    host: x.Host,
                    index: index,
                    blocked: listFirewallAddress.SingleOrDefault(fa => x.Target.Replace(@"/32", "").Equals(fa.Address))?.List.Equals("bloqueo") ?? false
                )
            ).ToList();
        }

        //const string listName = "TEST_LIST";
        //const string ipAddress = "192.168.1.1";
        //const string ipAddress2 = "192.168.1.2";
        //private static void PrintAddressList(ITikConnection connection)
        //{
        //    var addressLists = connection.LoadList<FirewallAddressList>(
        //        connection.CreateParameter("list", listName));
        //    foreach (FirewallAddressList addressList in addressLists)
        //    {
        //        Console.WriteLine("{0}{1}: {2} {3} ({4})", addressList.Disabled ? "X" : " ", addressList.Dynamic ? "D" : " ", addressList.Address, addressList.List, addressList.Comment);
        //    }
        //}

        #endregion
    }
}
