using System;
using System.Collections.Generic;
using System.Threading;

namespace RaceCondition
{
    // I am trying to create a simple race condition. My example is a producer-consumer model.

    // A classic example of a race condition is provided on the documentation page of the ThreadPool class in the MSDN.
    // https://msdn.microsoft.com/en-us/library/system.threading.threadpool%28v=vs.110%29.aspx
    // Here is the example
    //using System;
    //using System.Threading;

    //public class Example
    //{
    //    public static void Main()
    //    {
    //        // Queue the task.
    //        ThreadPool.QueueUserWorkItem(ThreadProc);
    //        Console.WriteLine("Main thread does some work, then sleeps.");
    //        Thread.Sleep(1000);

    //        Console.WriteLine("Main thread exits.");
    //    }

    //    // This thread procedure performs the task.
    //    static void ThreadProc(Object stateInfo)
    //    {
    //        // No state object was passed to QueueUserWorkItem, so stateInfo is null.
    //        Console.WriteLine("Hello from the thread pool.");
    //    }
    //}
    //// The example displays output like the following:
    ////       Main thread does some work, then sleeps.
    ////       Hello from the thread pool.
    ////       Main thread exits.
    class Program
    {
        private static List<string> customers = new List<string>();

        static void Main(string[] args)
        {
            Action loadCustomers = () =>
            {
                for (int i = 0; i < 10;)
                {
                    var customer = "Customer " + (++i).ToString();
                    Console.WriteLine($"Adding customer {customer}");
                    customers.Add(customer);
                    Thread.Sleep(1000);
                }

                Console.WriteLine("LoadCustomers ran to completion.\n");
            };

            Action displayCustomers = () =>
            {
                int i = 0;
                foreach(var customer in customers)
                {
                    Console.WriteLine($"Displaying customer: {++i}");
                    Console.WriteLine(customer);
                    Thread.Sleep(1000);
                }

                Console.WriteLine("DisplayCustomers ran to completion.\n");
            };

            var result1 = loadCustomers.BeginInvoke(null, null);
            var result2 = displayCustomers.BeginInvoke(null, null);

            result1.AsyncWaitHandle.WaitOne();
            result2.AsyncWaitHandle.WaitOne();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}