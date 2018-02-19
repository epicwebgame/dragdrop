using Ninject;
using System;

namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

#if DEBUG
            k.Bind<Foo>().ToMethod(m => FooFactory());
#endif

            var foo = k.Get<Foo>();

            Console.ReadKey();
        }

        public static Foo FooFactory()
        {
            Console.WriteLine("Before creating foo...");

            var foo = new Foo();

            Console.WriteLine("Foo created successfully...");

            return new Foo();
        }

    }

    class Foo
    {
        public Foo() { Console.WriteLine("Ctor");  }

        [Inject]
        public void RunMeImmediatelyAfterCreatingFoo()
        {
            Console.WriteLine("Set up method.");
        }

        [Inject]
        public void SetUp(int i)
        {
            Console.WriteLine("Set up method.");
        }
    }
}
