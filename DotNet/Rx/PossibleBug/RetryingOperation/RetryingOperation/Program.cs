using System;
using System.Net;
using System.Reactive.Linq;
using System.Threading;

namespace RetryingOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            RetryDownloadStringAsynchronously();

            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
        }

        static void RetryDownloadStringAsynchronously()
        {
            Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

            string url = "http://www.nonexistent.com";

            var observable = Observable.Start(() => DownloadString(url));

            observable.Retry(3).Subscribe(Console.WriteLine, Error, Completed);
        }

        static void Completed()
        {
            Console.WriteLine("The operation completed successfully.");
        }

        static void Error(Exception ex)
        {
            Console.WriteLine($"Error handler reports: There was an error: {ex.Message}");
        }

        static string DownloadString(string url)
        {
            try
            {
                Console.WriteLine($"DownloadString running on thread: {Thread.CurrentThread.ManagedThreadId}");

                return new WebClient().DownloadString(url);
            }
            catch
            {
                Console.WriteLine("Inside DownloadString: An exception occurred.");
                throw;
            }
        }
    }
}
