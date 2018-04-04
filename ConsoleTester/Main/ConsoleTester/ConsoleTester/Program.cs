using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{

    //Constructor default = sin parametros ó que el que es generado automaticamente cuando no hay ningun constructor definido.
    //solo es necesario especificar el llamado al constructor base cuando no existe constructor por default o queremos pasar algun parametro al constructor base.
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();

            Console.Read();
        }
    }

    public class A
    {
        public String Name { get; set; }

        public A()
        {
            Console.WriteLine("ClaseA");
        }

        public A(String nombre)
        {
            Console.WriteLine("ClaseANombre");
        }

    }

    public class B : A
    {
        public String Name { get; set; }

        public B()
        {
            Console.WriteLine("ClaseB");
        }
    }


    
}
