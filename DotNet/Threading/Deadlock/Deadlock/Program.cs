using System;
using System.Diagnostics;
using System.Threading;

namespace Deadlock
{
    // I started off simulating a deadlock and then had some questions about it.
    // See details at:
    // http://stackoverflow.com/questions/37544816/where-does-the-thread-pool-get-new-threads-from-when-its-total-available-worker
    // or at
    // http://stackoverflow.com/q/37544816/303685
    class Program
    {
        private static readonly object lockA = new object();
        private static readonly object lockB = new object();

        static void Main(string[] args)
        {
            int worker, io;

            ThreadPool.GetAvailableThreads(out worker, out io);

            Console.WriteLine($"Total number of thread pool threads: {worker}, {io}");
            Console.WriteLine($"Total threads in my process: {Process.GetCurrentProcess().Threads.Count}");
            Console.ReadKey();

            try
            {
                for (int i = 0; i < 1000000; i++)
                {
                    AutoResetEvent auto1 = new AutoResetEvent(false);
                    AutoResetEvent auto2 = new AutoResetEvent(false);

                    ThreadPool.QueueUserWorkItem(ThreadProc1, auto1);
                    ThreadPool.QueueUserWorkItem(ThreadProc2, auto2);

                    var allCompleted = WaitHandle.WaitAll(new[] { auto1, auto2 }, 20);

                    ThreadPool.GetAvailableThreads(out worker, out io);
                    var total = Process.GetCurrentProcess().Threads.Count;

                    if (allCompleted)
                    {    
                        Console.WriteLine($"All threads done: (Iteration #{i + 1}). Total: {total}, Available: {worker}, {io}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Timed out: (Iteration #{i + 1}). Total: {total}, Available: {worker}, {io}\n");
                    }
                }

                Console.WriteLine("Press any key to exit...");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception occurred.");
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.WriteLine("The program will now exit. Press any key to terminate the program...");
            }
            
            Console.ReadKey();
        }

        static void ThreadProc1(object state)
        {
            lock(lockA)
            {
                Console.WriteLine("ThreadProc1 entered lockA. Going to acquire lockB");

                lock(lockB)
                {
                    Console.WriteLine("ThreadProc1 acquired both locks: lockA and lockB.");

                    //Do stuff
                    Console.WriteLine("ThreadProc1 running...");
                }
            }

            if (state != null)
            {
                ((AutoResetEvent)state).Set();
            }
        }

        static void ThreadProc2(object state)
        {
            lock(lockB)
            {
                Console.WriteLine("ThreadProc2 entered lockB. Going to acquire lockA.");

                lock(lockA)
                {
                    Console.WriteLine("ThreadProc2 acquired both locks: lockA and lockB.");

                    // Do stuff
                    Console.WriteLine("ThreadProc2 running...");
                }
            }

            if (state != null)
            {
                ((AutoResetEvent)state).Set();
            }
        }
    }
}