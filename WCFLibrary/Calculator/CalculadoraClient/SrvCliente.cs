using CalculadoraMock.CalculadoraWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClient
{
    public class SrvCliente
    {
        public ISrvCalculadora SrvCalculadora;

        public SrvCliente(ISrvCalculadora srvCalculadora)
        {
            this.SrvCalculadora = srvCalculadora;
        }
    }
}
