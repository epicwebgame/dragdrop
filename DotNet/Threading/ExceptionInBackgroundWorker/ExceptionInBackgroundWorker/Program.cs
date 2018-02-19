using System;
using System.Threading;

namespace ExceptionInBackgroundWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((o) => { throw new InvalidOperationException("Threadpool thread threw an exception."); }, null);

                Thread.Sleep(500);
            }
            catch(InvalidOperationException invalidOperation)
            {
                Console.WriteLine(invalidOperation.Message);
            }

            Console.ReadKey();
        }
    }
}
