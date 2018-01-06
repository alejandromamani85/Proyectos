using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(CalculadoraClient.Initialize.SimpleInjectorInitializer), "Initialize")]
namespace CalculadoraClient.Initialize
{

    public class SimpleInjectorInitializer
    {
        #region Atributos estáticos
        private static SimpleInjector.Container Container { get; set; }
        #endregion

        #region Initializer
        public static void Initialize()
        {
            //Boolean mockMode = Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["MockMode"]);


            var configSec = Configuration.MyConfigSection.GetConfig();

            bool mockMode = false;
            Container = new Container();
            InitializeContainer(Container, mockMode);
            Container.Verify();
        }
        #endregion

        #region Register services
        private static void InitializeContainer(Container container, Boolean mockMode)
        {

            //var scopedLifestyle = new WebRequestLifestyle();
            container.Register<SrvCliente, SrvCliente>();
            if (mockMode)
            {
                container.Register<CalculadoraMock.CalculadoraWS.ISrvCalculadora, CalculadoraMock.SrvCalculadoraMock>();
            }
            else
            {
                container.Register<CalculadoraMock.CalculadoraWS.ISrvCalculadora>(() => new CalculadoraMock.CalculadoraWS.SrvCalculadoraClient());
                //container.RegisterInitializer<CalculadoraMock.CalculadoraWS.SrvCalculadoraClient>(client =>
                //{
                //    scopedLifestyle.WhenScopeEnds(container, () =>
                //    {
                //        try
                //        {
                //            client.InnerChannel.Dispose();
                //        }
                //        catch
                //        {
                //            // According to Marc Gravell we need to have a catch all here.
                //        }
                //    });
                //});
            }
        }
        #endregion


        #region Interfaz pública
        public static TService GetImplementation<TService>()
            where TService : class
        {
            var retorno = Container.GetInstance<TService>();
            return retorno;
        }
        #endregion
    }
}
