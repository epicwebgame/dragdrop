using System;
using System.Linq;
using System.Threading;

namespace ClosuresAreNotThreadSafe
{
    class Program
    {
        // This is not thread-safe
        // We need to ensure its safety
        private static string[] customers = new[] { "John", "Kathy", "Ramesh", "Paul" };

        private static readonly object syncLock = new object();

        static void Main(string[] args)
        {
            // This is ALSO not thread-safe, right?
            var numberOfCustomers = 0;

            var tIncrementor = new Thread(() =>
            {
                lock (syncLock)
                {
                    foreach (var customer in customers)
                    {
                        // Do something to the customer
                        customer.ToUpper();

                        // Just to let the other thread run concurrently
                        Thread.Sleep(500);

                        Interlocked.Increment(ref numberOfCustomers);
                        // numberOfCustomers++;

                        Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} working on customer {numberOfCustomers}.");
                    }
                }
            });

            var tDecrementor = new Thread(() =>
            {
                lock (syncLock)
                {
                    foreach (var customer in customers)
                    {
                        // Do something to the customer
                        customer.ToUpper();

                        // Just to let the other thread run concurrently
                        Thread.Sleep(100);

                        Interlocked.Decrement(ref numberOfCustomers);
                        // numberOfCustomers--;

                        Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} working on customer {numberOfCustomers}.");
                    }
                }
            });

            tIncrementor.Start();
            tDecrementor.Start();

            tIncrementor.Join();
            tDecrementor.Join();

            Console.WriteLine($"Number of customers: {numberOfCustomers}");

            Console.ReadKey();
        }
    }
}