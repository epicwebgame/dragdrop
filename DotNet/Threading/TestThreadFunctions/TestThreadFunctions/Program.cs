using System;
using System.Threading;

namespace TestThreadFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main thread";

            var t = JoiningAnAlreadyCompletedThread();

            JoiningIsIdempotent(t);

            Console.ReadKey();
        }
        
        static Thread JoiningAnAlreadyCompletedThread()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} ({Thread.CurrentThread.ManagedThreadId}): I'm done now.\n");
            })
            { Name = "Worker 1" };

            t.Start();

            // Give a long time-out so we know that the 
            // current thread did not wait the entire time-out
            // or that it didn't wait at all because the thread
            // we are joining on has already completed.
            t.Join(10000);

            Console.WriteLine($"{Thread.CurrentThread.Name} ({Thread.CurrentThread.ManagedThreadId}): I just joined on another thread that I knew was already completed even before I joined. See nothing happened. .NET doesn't punish you for joining a thread that has already completed, unlike POSIX systems, which do.\n");

            return t;
        }

        static void JoiningIsIdempotent(Thread threadToJoinOn)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} ({Thread.CurrentThread.ManagedThreadId}): I am about to join a thread that I already joined with earlier. I want to see if joining is idempotent.\n");

            // Joining is idempotent
            threadToJoinOn.Join();

            Console.WriteLine($"{Thread.CurrentThread.Name} ({Thread.CurrentThread.ManagedThreadId}): I just finished joining with a thread that I already joined with earlier. See! nothing happened. Joining is idempotent.\n");
        }
    }
}