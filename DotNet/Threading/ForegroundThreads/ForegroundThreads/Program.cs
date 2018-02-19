using System;
using System.Threading;

namespace ForegroundThreads
{
    // This is a program to test whether or not the application
    // will terminate when there is a pending foreground thread running.

    // In describing the difference between foreground and background threads, 
    // the documentation states that an application will terminate all
    // background threads when all foreground threads have finished execution.
    // This implies that the application will stall the main thread until
    // all foreground threads have completed execution. Let us see if this
    // is the case.

    // Quote:
    // A managed thread is either a background thread or a foreground thread. 
    // Background threads are identical to foreground threads with one exception: 
    // a background thread does not keep the managed execution environment running. 
    // Once all foreground threads have been stopped in a managed process (where the .exe file is a managed assembly), 
    // the system stops all background threads and shuts down. 
    // Source: https://msdn.microsoft.com/en-us/library/h339syd0%28v=vs.110%29.aspx

    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(() => { 20000.Times(() => { Console.WriteLine("Hello"); }); });
            t.Start();

            Console.WriteLine("Press any key to exit the main thread...");
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static void Times(this int numTimes, Action action)
        {
            for (int i = 0; i < numTimes; i++, action()) ;
        }
    }
}