using Ninject;
using System;

namespace ConsoleApplication15
{
    interface ILiquid { }
    class Milk : ILiquid { }
    class Water : ILiquid { }

    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            k.Bind<ILiquid>().To<Water>().Named("water");
            k.Bind<ILiquid>().To<Milk>().Named("milk");

            var liquid1 = k.Get<ILiquid>("milk");
            Console.WriteLine(liquid1.GetType().Name);

            k.Bind<Foo>().ToSelf().InSingletonScope();

            var foo1 = k.Get<Foo>();
            var foo2 = k.Get<Foo>();
            Console.WriteLine(object.ReferenceEquals(foo1, foo2));

            // Console.WriteLine(foo.Bar.Gar.GetType().Name);

            Console.ReadKey();
        }
    }

    class Foo
    {
        public Bar Bar { get; set; }

        public Foo(Bar b) { Bar = b; }
    }

    class Bar
    {
        //[Inject]
        //public string Name { get; set; }

        [Inject]
        public Gar Gar { get; set; }
    }

    class Gar { }
}
