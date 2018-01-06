using CalculadoraMock.CalculadoraWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMock
{
    public class SrvCalculadoraMock : ISrvCalculadora
    {
        public double Add(double n1, double n2)
        {
            return 4;
        }

        public Task<double> AddAsync(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public double Substract(double n1, double n2)
        {
            return 2;
        }

        public Task<double> SubstractAsync(double n1, double n2)
        {
            throw new NotImplementedException();
        }
    }
}
