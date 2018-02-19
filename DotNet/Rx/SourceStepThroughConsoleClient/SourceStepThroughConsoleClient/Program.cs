using System;
using System.Reactive.Linq;

namespace SourceStepThroughConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = Observable.Range(5, 8);

            o.Subscribe(Console.WriteLine);

            Console.ReadKey();
        }
    }
}