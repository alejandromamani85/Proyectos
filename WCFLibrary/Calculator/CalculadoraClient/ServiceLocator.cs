using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClient
{
    public class ServiceLocator : IServiceLocator
    {
        private IDictionary<object, object> services;

        public ServiceLocator()
        {
            services = new Dictionary<object, object>();

            this.services.Add(typeof(CalculadoraMock.CalculadoraWS.ISrvCalculadora), new CalculadoraMock.SrvCalculadoraMock());
            this.services.Add(typeof(CalculadoraMock.CalculadoraWS.ISrvCalculadora), new CalculadoraMock.CalculadoraWS.SrvCalculadoraClient());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("El servicio Solicitado no se encuentra registrado.");
            }
        }
    }
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
