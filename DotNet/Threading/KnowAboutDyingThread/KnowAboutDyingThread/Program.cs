using System;
using System.Diagnostics;
using System.Threading;

namespace KnowAboutDyingThread
{
    // Source: https://msdn.microsoft.com/en-us/library/h339syd0%28v=vs.110%29.aspx
    // When the runtime stops a background thread because the process is shutting down, 
    // no exception is thrown in the thread. However, when threads are stopped because the 
    // AppDomain.Unload method unloads the application domain, a ThreadAbortException is 
    // thrown in both foreground and background threads.

    // I am trying that out
    // I asked a question here about it: http://stackoverflow.com/questions/37552668/is-there-a-way-to-know-if-a-thread-is-being-aborted-because-the-program-is-termi
    // Permalink: http://stackoverflow.com/q/37552668/303685

    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
            ThreadPool.QueueUserWorkItem(Do);
            var t = new Thread(Do);
            t.Name = "Foreground";
            t.Start();

            Thread.Sleep(1500);
            Process.GetCurrentProcess().Kill();
        }

        private static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            Debug.Print("Unloading current appdomain...");
        }

        static void Do(object state)
        {
            try
            {
                Debug.Print(string.Format($"[#{Thread.CurrentThread.ManagedThreadId}] [{Thread.CurrentThread.Name ?? "Worker"}]Starting to do stuff."));
                Thread.Sleep(5000);
                Debug.Print(string.Format($"[#{Thread.CurrentThread.ManagedThreadId}] [{Thread.CurrentThread.Name ?? "Worker"}]Slept for 5 seconds. Now finishing up the doing of stuff."));
            }
            catch(ThreadAbortException abort)
            {
                Debug.Print(string.Format($"[#{Thread.CurrentThread.ManagedThreadId}] [{Thread.CurrentThread.Name ?? "Worker"}]Do got ThreadAbortException: {abort.GetType().Name}: {abort.Message}"));
            }
            catch(Exception ex)
            {
                Debug.Print(string.Format($"[#{Thread.CurrentThread.ManagedThreadId}] [{Thread.CurrentThread.Name ?? "Worker"}]Do had an exception: {ex.GetType().Name}: {ex.Message}"));
            }
        }
    }
}