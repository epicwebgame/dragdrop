using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace RunAndDo
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = GetValues().ToObservable(Scheduler.CurrentThread);

            Console.WriteLine("Starting Observable Sequence 1");
            using (o.Subscribe(v => Console.WriteLine(v)))
            {
            }


            var o2 = o.Do(v => { Console.WriteLine($"Do {v}"); });
            Console.WriteLine("\nStarting Observable Sequence 1");
            using (o2.Subscribe(v => Console.WriteLine(v)))
            {

            }

            Console.WriteLine("\nStarting Observable Sequence 3");
            using (Observable.Range(1, 5).Do(v => Console.WriteLine($"Do {v}")).Subscribe(Console.WriteLine)) { }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static IEnumerable<int> GetValues()
        {
            Console.WriteLine("Side effect A");
            yield return 1;

            Console.WriteLine("Side effect B");
            yield return 2;
        }
    }
}
