using CalculadoraClient;
using CalculadoraClient.Initialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceLocator();
            InjectionOfDependencies();
        }

        private static void ServiceLocator()
        {
            ServiceLocator srvLocator = new CalculadoraClient.ServiceLocator();
            
        }

        private static void InjectionOfDependencies()
        {
            SimpleInjectorInitializer.Initialize();
            SrvCliente wsCliente = SimpleInjectorInitializer.GetImplementation<SrvCliente>();
            Console.WriteLine("Suma : {0}", wsCliente.SrvCalculadora.Add(5, 5));
            Console.Read();
        }
    }
}
