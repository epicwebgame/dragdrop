using System;
using Ninject;
using Ninject.Modules;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NiceModule(), new BadModule());
            kernel.Bind<ILiquid>().To<Milk>();

            var liquid = kernel.Get<ILiquid>();
            var water = kernel.Get<Water>();
            var element = kernel.Get<IElement>();

            Console.WriteLine(liquid.GetType().Name);
            Console.WriteLine(water.GetType().Name);
            Console.WriteLine(element.GetType().Name);

            Console.ReadKey();
        }
    }

    class NiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILiquid>().To<Water>();
        }
    }

    class BadModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILiquid>().To<Milk>();
            Bind<IElement>().To<Hydrogen>();
        }
    }

    interface IElement { }

    class Hydrogen : IElement { }

    interface ILiquid { }

    class Water : ILiquid { }

    class Pepsi : ILiquid { }

    class Milk : ILiquid { }
}
