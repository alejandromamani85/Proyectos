using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraWS.Contracts
{
    [ServiceContract]
    public interface ISrvCalculadora
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Substract(double n1, double n2);
    }
}
