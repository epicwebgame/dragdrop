using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

// For the hell that ensues in handling exceptions and in unhandled exceptions
// that ocurr in the APM method, please see my StackOverflow question here:
// http://stackoverflow.com/questions/37645872/why-does-an-unhandled-exception-in-this-background-thread-not-terminate-my-proce
// Permalink: http://stackoverflow.com/q/37645872/303685
namespace OriginalCallStackIsLostOnRethrow
{
    class Program
    {
        public async Task FooAsync()
        {
            await Task.Run(() => { });
        }

        static void Main(string[] args)
        {
            try
            {
                // A();
                // A1();
                // A2();
                // A3();

                //var t = new Thread(() => {
                //    throw new DivideByZeroException();
                //});
                // t.Start();




                // TRY WITH TPL SUPPORT BUT NO LANGUAGE FEATURE SUPPORT

                // Observe the exception
                // Wait or Result or task.Exception
                // observes the exception
                // A4().Wait();

                // Observe the exception
                // where the TCS explicitly sets the exception
                // var task = A5();
                /// task.Wait();
                // A5().Wait();

                // Let the exception go unobserved
                // var task = A4();
                // var task = A5();
                // task.ContinueWith(t => { Console.WriteLine("Done"); });


                // Let the exception go unobserved
                // but handle the TaskScheduler.UnobservedTaskException
                // TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
                // var task = A4();
                var task = A5();
                task.ContinueWith(t => { Console.WriteLine("Done"); });
                Console.WriteLine("Press a key to forceably perform garbage collection...");
                Console.ReadKey();
                GC.Collect();
                Thread.Sleep(10000);

                //Task.Factory.ContinueWhenAll(new[] { task, task2 },
                //    tasks =>
                //    {
                //        Console.WriteLine("Press a key to forceably perform garbage collection...");
                //        Console.ReadKey();
                //        GC.Collect();
                //    });


                // NOW LET'S TRY THAT WITH THE async, await LANGUAGE SUPPORT FEATURES
                //var task = CallerOf6();
                //task.ContinueWith(t => { Console.WriteLine("Done"); });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex);
            }
            finally
            {
                // Console.ReadKey();
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine($"\n\nUnobserved exception: {e.Exception.GetType().FullName}\n\n{e.ToString()}");
        }

        static void A() { B(); }
        static void B() { C(); }
        static void C() { D(); }
        static void D()
        {
            Console.Write("Enter the divisor: ");
            var divisor = Console.ReadLine();
            Console.WriteLine(25 / int.Parse(divisor));
        }

        static void A1() { B1(); }
        static void B1() { C1(); }
        static void C1() { D1(); }
        static void D1()
        {
            try
            {
                Console.Write("Enter the divisor: ");
                var divisor = Console.ReadLine();
                Console.WriteLine(25 / int.Parse(divisor));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        static void A2() { B2(); }
        static void B2() { C2(); }
        static void C2() { D2(); }
        static void D2()
        {
            Action action = () => 
            {
                try
                {
                    Console.WriteLine($"D2 called on worker #{Thread.CurrentThread.ManagedThreadId}. Exception will occur while running D2");
                    throw new DivideByZeroException();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
            action.BeginInvoke(ar =>
            {
                ((Action)((ar as AsyncResult).AsyncDelegate)).EndInvoke(ar);

                Console.WriteLine($"D2 completed on worker thread #{Thread.CurrentThread.ManagedThreadId}");
            }, null);
        }

        static void A3() { B3(); }
        static void B3() { C3(); }
        static void C3() { D3(); }
        static void D3()
        {
            Action action = () => { Console.WriteLine($"D2 called on worker #{Thread.CurrentThread.ManagedThreadId}."); };
            action.BeginInvoke(ar =>
            {
                try
                {
                    Console.WriteLine($"D2 completed on worker thread #{Thread.CurrentThread.ManagedThreadId}. Oh, but wait! Exception!");
                    throw new DivideByZeroException();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }, null);
            
        }

        static Task A4() { return B4(); }
        static Task B4() { return C4(); }
        static Task C4() { return D4(); }
        static Task D4()
        {
            Console.Write("Enter the divisor: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine((24 / n).ToString());
            return new TaskCompletionSource<object>().Task;
        }

        static Task A5() { return B5(); }
        static Task B5() { return C5(); }
        static Task C5() { return D5(); }
        static Task D5()
        {
            var tcs = new TaskCompletionSource<object>();

            try
            {
                Console.Write("Enter the divisor: ");
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine((24 / n).ToString());

                tcs.SetResult(null);
            }
            catch(Exception ex)
            {
                tcs.SetException(ex);
            }

            return tcs.Task;
        }

        async static Task CallerOf6()
        {
            try
            {
                await A6();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex);
            }

        }
        async static Task A6() { await B6(); }
        async static Task B6() { await C6(); }
        async static Task C6() { await D6(); }
        async static Task D6()
        {
            Console.Write("Enter the divisor: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine((24 / n).ToString());
            return;
        }
    }
}
