using System;
using System.Threading;

namespace DelegateBeginInvoke
{
    class Program
    {
        delegate void WorkHandler(int i);
        delegate int IntReturner();

        static void Main(string[] args)
        {
            WorkHandler wh = DoSomething;
            Thread.CurrentThread.Name = "Main Thread";
            var ar = wh.BeginInvoke(20, asyncResult => { Console.WriteLine("DoSomething Done"); }, null);

            for (int i = 0; i < 20; i++)
            {
                IntReturner ir = GetInteger;
                var ar2 = ir.BeginInvoke(asyncResult =>
                {
                    Console.WriteLine("GetInteger Done");
                }, null);
            }

            int remainingWorkerThreads, remainingIOThreads;
            ThreadPool.GetAvailableThreads(out remainingWorkerThreads, out remainingIOThreads);
            Console.WriteLine($"While the worker thread is doing its work, here we are in the {Thread.CurrentThread.Name} again. Remaining threads: {remainingWorkerThreads}");

            Console.ReadKey();
        }

        static void DoSomething(int i)
        {
            for (int j = 0; j < i; j++)
            {
                int remainingWorkerThreads, remainingIOThreads;
                ThreadPool.GetAvailableThreads(out remainingWorkerThreads, out remainingIOThreads);
                Console.WriteLine($"{Thread.CurrentThread.Name ?? "DoSomething Thread"} doing work with item {j}. Remaining threads: {remainingWorkerThreads}");
                Thread.Sleep(500);
            }
        }

        static int GetInteger()
        {
            int remainingWorkerThreads, remainingIOThreads;
            ThreadPool.GetAvailableThreads(out remainingWorkerThreads, out remainingIOThreads);
            Console.WriteLine($"{Thread.CurrentThread.Name ?? "GetInteger Thread"} doing work. Remaining threads: {remainingWorkerThreads}");
            return new Random().Next();
        }
    }
}
