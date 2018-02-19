using System;
using Ninject;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            // Contextual binding
            // 1) Named mapping
            var k = new StandardKernel();

            k.Bind<ILiquid>().To<Water>().Named("water");
            k.Bind<ILiquid>().To<Milk>().Named("milk");
            var liquid1 = k.Get<ILiquid>("milk");
            Console.WriteLine(liquid1.GetType().Name);

            // Contextual binding
            // 2) Attribute mapping
            k.Bind<IElement>().To<Nitrogen>();
            var compound1 = k.Get<Compound>();
            Console.WriteLine("First Element: {0}, Second Element: {1}",
                compound1.First.GetType().Name,
                compound1.Second.GetType().Name);

            k.Bind<IElement>()
                .To<Hydrogen>()
                .WhenTargetHas<LighterElementAttribute>();

            k.Bind<IElement>()
                .To<Oxygen>()
                .WhenTargetHas<HeavierElementAttribute>();

            var compound2 = k.Get<Compound>();
            Console.WriteLine("First Element: {0}, Second Element: {1}",
                compound2.First.GetType().Name,
                compound2.Second.GetType().Name);

            Console.ReadKey();
        }
    }

    interface ILiquid { }
    class Water : ILiquid { }
    class Milk : ILiquid { }

    interface IElement { }
    class Hydrogen : IElement { }
    class Oxygen : IElement { }
    class Nitrogen : IElement { }

    class Compound
    {
        public IElement First { get; set; }
        public IElement Second { get; set; }

        public Compound([LighterElement]IElement first, 
            [HeavierElement]IElement second)
        {
            First = first;
            Second = second;
        }
    }

    class LighterElementAttribute : Attribute { }
    class HeavierElementAttribute : Attribute { }
}
