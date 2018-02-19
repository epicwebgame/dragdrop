using System;

namespace ForeachLoopCatch
{
    // If you have a catch in a foreach loop, does handling an error in the catch block
    // allow the foreach loop to resume execution? I think not.
    // However, the code on this page seems to, I suspect wrongly, demonstrate that it does.
    // See the code in the section titled "Synchronous and Asynchronous Sockets"
    // http://www.bearcanyon.com/dotnet/

    // So it turns out that it does. I never knew this.
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var c in "Hello")
            {
                try
                {
                    Console.WriteLine(c);

                    if (c % 2 == 0)
                        throw new InvalidOperationException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
