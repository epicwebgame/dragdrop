using System;
using Ninject;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            k.Bind<Foo>().ToConstructor(c => new Foo(c.Inject<Gar>()));

            var foo = k.Get<Foo>();

            Console.ReadKey();
        }
    }

    class Foo
    {
        public Foo() { }

        public Foo(Gar g) { Console.WriteLine("The one with Gar"); }

        [Inject]
        public Foo(Gar g, Har h) { }
    }
    class Gar { }
    class Har { }
}