using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            var foo = k.Get<Foo>();
            foo.Method1();

            Console.ReadKey();
        }
    }

    class Foo
    {
        public Foo()
        {
            Console.WriteLine("Ctor");
        }

        [Inject]
        public void Method1()
        {
            Console.WriteLine("Method1");
        }

        [Inject]
        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
}
