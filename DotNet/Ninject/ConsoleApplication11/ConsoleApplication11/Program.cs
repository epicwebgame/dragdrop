using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<ILiquid, Water>();
            container.RegisterType<ILiquid, Milk>();

            var liquid = container.Resolve<ILiquid>();

            Console.WriteLine(liquid.GetType().Name);

            Console.ReadKey();
        }
    }

    interface IElement { }

    class Hydrogen : IElement { }

    interface ILiquid { }

    class Water : ILiquid { }

    class Pepsi : ILiquid { }

    class Milk : ILiquid { }
}
