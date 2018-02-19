using System;
using Ninject;
using Ninject.Parameters;

namespace NinjectConstructorSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            k.Bind<Bar>().ToSelf()
                .WithConstructorArgument("d", 4.0)
                .WithConstructorArgument("i", 2);

            var bar1 = k.Get<Bar>();
            var bar2 = k.Get<Bar>();

            var anotherBar = k.Get<Bar>(new ConstructorArgument("d", 5.0));
            var anotherBar2 = k.Get<Bar>();
            var anotherBar3 = k.Get<Bar>(
                new ConstructorArgument("d", (double)7),
                new ConstructorArgument("i", 9));

            Console.WriteLine("{0}, {1}", bar1.D, bar1.I);
            Console.WriteLine("{0}, {1}", bar2.D, bar2.I);
            Console.WriteLine("{0}, {1}", anotherBar.D, anotherBar.I);
            Console.WriteLine("{0}, {1}", anotherBar2.D, anotherBar2.I);
            Console.WriteLine("{0}, {1}", anotherBar3.D, anotherBar3.I);

            Console.ReadKey();
        }
    }

    class Foo
    {
        [Inject]
        public Foo(Bar b)
        {
            Console.WriteLine("Foo Ctor with Bar only");
        }

        public Foo(Bar b, Har h)
        {
            Console.WriteLine("Foo Ctor with Bar and Har");
        }
    }

    class Bar
    {
        public Bar() { }

        public double D { get; set; }
        public int I { get; set; }

        public Bar(double d, int i)
        {
            D = d;
            I = i;
            Console.WriteLine("Bar with double: " + d.ToString() + " and int i: " + i.ToString());
        }

        public Bar(Gar g)
        {
            Console.WriteLine("Bar ctor with Gar.");
        }

        public Bar(Gar g, Har h, Tar t)
        {
            Console.WriteLine("Bar ctor with gar, har and tar.");
        }
    }

    class Tar { }
    class Gar { }
    class Har { }
}