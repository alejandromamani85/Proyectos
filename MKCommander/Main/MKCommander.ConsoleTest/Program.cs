using MKCommander.Logic;
using MKCommander.Logic.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tik4net.Objects.Interface;
using tik4net.Objects.Queue;
using tik4net.Objects.Tool;

namespace MKCommander.ConsoleTest
{
    class Program
    {

        //Prueba de Pings
        static void Main(string[] args)
        {
            var servicio = new SrvClient();
            var clients = servicio.GetClientsAll();
            foreach (QueueSimple qs in clients)
            {
                Console.WriteLine(string.Format("Name: {0} - Target: {1} - MaxLimit: {2} - BurstLimit: {3} - LimitAt: {4} - Rate: {5}", qs.Name, qs.Target, qs.MaxLimit, qs.BurstLimit, qs.LimitAt, qs.Rate));
            }
            Console.ReadKey();
        }

        ////Prueba de Pings
        //static void Main(string[] args)
        //{
        //    var servicio = new ServicioTest();
        //    var pings= servicio.Ping("www.mercadolibre.com.ar", 2);
        //    foreach (ToolPing p in pings)
        //    {
        //        Console.WriteLine(string.Format("Host: {0} - Sent: {1} - Received: {2} - Time: {3}", p.Host, p.Sent, p.Received, p.Time));
        //    }
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    var servicio = new ServicioTest();
        //    var interfaces = servicio.GetInterfaces();
        //    foreach (Interface i in interfaces)
        //    {
        //        Console.WriteLine(string.Format("MAC: {0} - Name: {1} - Comment: {2} - Disabled: {3}", i.MacAddress, i.Name, i.Comment, i.Disabled));
        //    }
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    MK mikrotik = new MK("192.168.60.160");
        //    if (!mikrotik.Login("admin", "123qwe."))
        //    {
        //        Console.WriteLine("Could not log in");
        //        mikrotik.Close();
        //        return;
        //    }
        //    mikrotik.Send("/system/identity/getall");
        //    mikrotik.Send(".tag=sss", true);
        //    foreach (string h in mikrotik.Read())
        //    {
        //        Console.WriteLine(h);
        //    }
        //    Console.ReadKey();
        //}
    }
}
