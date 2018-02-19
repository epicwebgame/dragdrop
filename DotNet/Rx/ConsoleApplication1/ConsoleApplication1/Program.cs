using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo();

            Console.ReadKey();
        }

        async static Task Foo()
        {
            await Bar();
        }

#pragma warning disable 1998

        static async Task Bar()
        {
            // long work
            Thread.SpinWait(100000000);
        }
#pragma warning restore 1998
    }
}
