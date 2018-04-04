using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLCompare
{
    class Program
    {
        static void Main(string[] args)
        {

            var xmlStr = File.ReadAllText(@"C:\AleTest\XML\Response\CotizacionResponse01SxSOAV5.xml");


            var str = XElement.Parse(xmlStr);

            var result = str.Elements("SxSubProductoPlanDTO").Select(x => new { IdOpcion = x.Element("IdOpcion").Value, PrecioTotal = x.Element("PrecioTotal").Value }).OrderBy(x => x.IdOpcion).ToList();
            foreach (var item in result)
            {
                 Console.WriteLine(String.Format("IdOpcion: {0} - PrecioTotal: {1}", item.IdOpcion, item.PrecioTotal));
            }

            Console.Read();
        }
    }
}
