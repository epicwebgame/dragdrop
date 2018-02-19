using System;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquid = new Milk();
            var powderedCoffee = new InstantCoffeePowder();

            var coffeeMaker = new CoffeeMaker(liquid, powderedCoffee);


            Console.ReadKey();
        }
    }

    class CoffeeMaker
    {
        public CoffeeMaker(ILiquid liquid, IPowderedCoffee powderedCoffee)
        {
            _liquid = liquid;
            _powderedCoffee = powderedCoffee;
        }

        private ILiquid _liquid = null;
        private IPowderedCoffee _powderedCoffee = null;

        public BlackCoffee MakeCoffee()
        {
            return new BlackCoffee();
        }
    }

    class Water : ILiquid { }
    class Milk : ILiquid { }

    class GroundCoffee : IPowderedCoffee { }
    class FilteredCoffee : IPowderedCoffee { }
    class InstantCoffeePowder : IPowderedCoffee { }

    class BlackCoffee { }

    interface ILiquid { }
    interface IPowderedCoffee { }
}
