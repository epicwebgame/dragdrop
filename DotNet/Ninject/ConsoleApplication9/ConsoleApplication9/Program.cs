using Ninject;
using System;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();
            var foo = k.Get<Foo>();
            Console.ReadKey();
        }
    }

    class Bar { }
    class Gar { }
    class Foo
    {
        public Foo(Bar b) { Console.WriteLine("Bar");  }
        public Foo(Bar b, Gar g) { Console.WriteLine("Bar and gar"); }
    }
}
