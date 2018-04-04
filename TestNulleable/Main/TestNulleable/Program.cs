using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNulleable
{
    class Program
    {


        static void Main(string[] args)
        {
            DateTime fechaNulleable = null;


            //Console.WriteLine($"FechaNulleable.HasValue: {fechaNulleable.HasValue}");
            //Console.WriteLine($"FechaNulleable.Value: {fechaNulleable.Value}");
            var convertIsnull = Convert.ToString(fechaNulleable);
            Console.WriteLine($"FechaNulleable: {Convert.ToString(fechaNulleable)}");
            Console.ReadKey();
        }
    }


}
