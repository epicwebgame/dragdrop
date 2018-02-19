using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;

namespace RxViaNuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable<int> o = Observable.Range(1, 10);
            using (o.Subscribe(i => { Console.WriteLine(i); },
                (ex) => { Console.WriteLine(ex.Message); },
                () => { Console.WriteLine("No more items to observe."); }
                    ))
            {
                Console.WriteLine("Press any key to unsubscribe.");
                Console.ReadKey();
            }

            Console.WriteLine();
            Console.WriteLine("We will now observe strings");

            var strings = new Collection<string> { "First", "Second", "Third", "Fourth" };
            IObservable<string> observableStrings = strings.ToObservable();
            var observer = Observer.Create<string>(
                s => { Console.WriteLine(s); Thread.Sleep(1000); },
                (ex) => { Console.WriteLine(ex.Message); },
                () => { Console.WriteLine("Reached the end of the observable strings stream."); });
            using (observableStrings.Subscribe(observer))
            {
                ThreadPool.QueueUserWorkItem(newValue =>
                {
                    strings.Add((string)newValue);
                    Thread.Sleep(100);
                }, "Fifth");

                ThreadPool.QueueUserWorkItem(newValue =>
                {
                    strings.Add((string)newValue);
                    Thread.Sleep(100);
                }, "Sixth");

                ThreadPool.QueueUserWorkItem(newValue =>
                {
                    strings.Add((string)newValue);
                    Thread.Sleep(100);
                }, "Seventh");

                Thread.Sleep(1000);
                
                Console.WriteLine("Press any key to unsubscribe.");
                Console.ReadKey();
            }
        }
    }
}
