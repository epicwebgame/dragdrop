using System;
using Ninject;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();
            k.Bind<Foo>().ToSelf().InSingletonScope();


            var foo1 = k.Get<Foo>();
            var foo2 = k.Get<Foo>();

            Console.WriteLine(object.ReferenceEquals(foo1, foo2));

            Console.ReadKey();
        }
    }

    class Foo { }
}
