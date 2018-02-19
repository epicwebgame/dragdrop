using System;
using System.Threading;

namespace ExceptionsInThreads
{
    // This page https://msdn.microsoft.com/en-us/library/6kac2kdh%28v=vs.110%29.aspx says
    // Do handle exceptions in threads. Unhandled exceptions in threads, even background threads, generally terminate the process.
    // I am testing this out

    // Conclusion: That's right. It doesn't even enter the catch block in the main method. 
    // It just stops the entire program.
    // It makes sense that it shouldn't enter the catch block of the main / calling thread because the thread
    // on the thread pool (or your own foreground thread that you creatd using the Thread class) 
    // in which the exception occurred is not called synchronously. It runs in its
    // own time and the return instruction from it doesn't and shouldn't land it into the catch block
    // of the calling thread, i.e. the main function in this case.
    // However, it does enter a catch block in the thread procedure if there is one.

    class Program
    {
        static void Main(string[] args)
        {
            var auto1 = new AutoResetEvent(false);
            
            try
            {
                // Run each thread on the thread pool
                ThreadPool.QueueUserWorkItem(ExceptionThrowerAndCatcher, auto1);
                // ThreadPool.QueueUserWorkItem(ExceptionThrower);

                auto1.WaitOne();

                // Run each thread on a separate foreground thread
                var t1 = new Thread(ExceptionThrowerAndCatcher);
                t1.Start();
                t1.Join();

                // var t2 = new Thread(ExceptionThrower);
                // t2.Start();
                // t2.Join();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ExceptionThrower(object state)
        {
            Console.WriteLine("Exception thrower running. Going to divide by zero.");
            throw new DivideByZeroException();
        }

        static void ExceptionThrowerAndCatcher(object state)
        {
            try
            {
                Console.WriteLine("Exception thrower and catcher running. Going to divide by zero.");
                throw new DivideByZeroException();
            }
            catch(DivideByZeroException d)
            {
                Console.WriteLine("You shouldn't divide anything by zero.");
            }

            AutoResetEvent auto = null;

            if (state != null && ((auto = (AutoResetEvent)state) != null))
                auto.Set();
        }
    }
}