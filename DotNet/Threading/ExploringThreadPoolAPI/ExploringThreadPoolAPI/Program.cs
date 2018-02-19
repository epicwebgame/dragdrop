using System;
using System.Threading;

namespace ExploringThreadPoolAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
            Console.WriteLine();
            ThreadPool.QueueUserWorkItem(o => { DoWork(); });
            ThreadPool.QueueUserWorkItem(o => { DoWork(); });
            ThreadPool.QueueUserWorkItem(o => { DoWork(); });
            ThreadPool.QueueUserWorkItem(o => { DoWork(); });
            Console.ReadKey();
        }

        static void DoWork()
        {
            int minWorkerThreads, minIOThreads, maxWorkerThreads, maxIOThreads, availableWorkerThreads, availableIOThreads;

            ThreadPool.GetMinThreads(out minWorkerThreads, out minIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxIOThreads);
            ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availableIOThreads);

            Console.WriteLine($"Min: {minWorkerThreads}, {minIOThreads}");
            Console.WriteLine($"Max: {maxWorkerThreads}, {maxIOThreads}");
            Console.WriteLine($"Available: {availableWorkerThreads}, {availableIOThreads}");
        }
    }
}
