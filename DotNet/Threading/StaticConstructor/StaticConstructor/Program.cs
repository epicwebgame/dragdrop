using System;
using System.Threading;

namespace StaticConstructor
{
    // The documentation says:
    // For example, if a class constructor starts a new thread, 
    // and the thread procedure calls a static member of the class, 
    // the new thread blocks until the class constructor completes.
    // Source: https://msdn.microsoft.com/en-us/library/1c9txz50%28v=vs.110%29.aspx


    // Managed Threading Best Practices
    // Static Members and Static Constructors
    // A class is not initialized until its class constructor (static constructor in C#, 
    // Shared Sub New in Visual Basic) has finished running. To prevent the 
    // execution of code on a type that is not initialized, the common language 
    // runtime blocks all calls from other threads to static members of the 
    // class (Shared members in Visual Basic) until the class constructor has finished running.

    // For example, if a class constructor starts a new thread, and the 
    // thread procedure calls a static member of the class, the new thread 
    // blocks until the class constructor completes.

    // This applies to any type that can have a static constructor.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Foo.Bar);

            Console.WriteLine("Main thread resumes execution.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class Foo
    {
        public static readonly int Bar = 2;

        static Foo()
        {
            Console.WriteLine("Entered Foo static constructor");
            var t = new Thread(Do);
            t.Start();
            Thread.Sleep(2000);
            Console.WriteLine("Rest of the constructor after the call to the Do method");
        }

        static void Do()
        {
            Console.WriteLine("Doing...");
            Thread.Sleep(2000);
            Console.WriteLine("Done");
        }
    }
}