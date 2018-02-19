using System;
using Ninject;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            k.Bind<ILiquid>().To<Water>();
            k.Bind<IPowderedCoffee>().To<GroundCoffee>();

            var coffeeMaker = k.Get<CoffeeMaker>();
            coffeeMaker.MakeBlackCoffee();

            Console.ReadKey();   
        }
    }

    interface ILiquid { }
    class Water : ILiquid { }

    interface IPowderedCoffee { }
    class GroundCoffee : IPowderedCoffee { }

    abstract class Coffee { }
    class BlackCoffee : Coffee { }

    class CoffeeMaker
    {
        [Inject]
        public ILiquid Liquid { get; set; }

        [Inject]
        public IPowderedCoffee PowderedCoffee { get; set; }

        public Coffee MakeBlackCoffee()
        {
            // Use them to make coffee
            Console.WriteLine("Making coffee with {0} and {1}.",
                Liquid.GetType().Name,
                PowderedCoffee.GetType().Name);

            return new BlackCoffee();
        }
    }
}
