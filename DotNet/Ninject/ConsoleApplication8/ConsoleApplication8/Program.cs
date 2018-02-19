using Ninject;
using System;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new MyModule(), new YourModule());
            //kernel.Bind<IElement>().To<Nitrogen>().WhenTargetHas<RedAttribute>();
            //kernel.Bind<IElement>().To<Oxygen>();

            //var water = kernel.Get<Water>();
            //var coffee = kernel.Get<IPowderedCoffee>();


            //var compound = kernel.Get<Compound>();
            //Console.WriteLine(compound.ToString());

            var element = kernel.Get<IElement>();
            Console.WriteLine(element.GetType().Name);

            Console.ReadKey();
        }
    }

    class RedAttribute : Attribute
    {

    }

    class MyModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IPowderedCoffee>().To<GroundCoffee>();
            Bind<IElement>().To<Nitrogen>();
        }
    }

    class YourModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IElement>().To<Oxygen>();
        }
    }

    class Water { }
    class Milk { }

    interface IPowderedCoffee { }
    class GroundCoffee : IPowderedCoffee { }
    class FilteredCoffee : IPowderedCoffee { }

    interface IElement { }
    class Hydrogen : IElement { }
    class Oxygen : IElement { }
    class Nitrogen : IElement
    {
        public Nitrogen() { Console.WriteLine("No parameters."); }
        public Nitrogen(string s)
        {
            Console.WriteLine("with string");
        }
        public Nitrogen(double d, string s)
        {
            Console.WriteLine("with double and string");
        }
        public Nitrogen(Foo foo) { Console.WriteLine("with foo.");  }
    }

    class Foo { }

    class Compound
    {
        public Compound(IElement first, [Red]IElement second)
        {
            First = first;
            Second = second;
        }

        public IElement First { get; set; }
        public IElement Second { get; set; }

        public override string ToString()
        {
            return string.Format("{0} and {1}", First.GetType().Name, Second.GetType().Name);
        }
    }
}