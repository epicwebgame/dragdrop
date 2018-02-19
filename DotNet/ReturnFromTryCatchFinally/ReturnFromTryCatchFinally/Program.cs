using System;

namespace ReturnFromTryCatchFinally
{
    // Just comparing with JavaScript try..catch..finally which is wild
    // There, anything can be inside anything.
    // Anything can be thrown
    // Any block can have a return statement / expression.
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Foo
    {
        public bool Do(int a, int n)
        {
            try
            {
                Console.WriteLine("Inside try.");

                try
                {
                    var d = ++a / --n;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Nested try exception caught.");
                }

                if (n == 0)
                    throw new DivideByZeroException();

                if (a % n == 0)
                throw new Exception("Oops!");

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    Console.WriteLine("Inside nested try that was inside a catch.");

                    if (a > 2 || n < 5) throw new Exception("Oops!");
                }
                catch(Exception e)
                {
                    return false;
                }

                return false;
            }
            finally
            {

                while (n < 100) n++;

                try
                {
                    if (a / 4 == n) throw new Exception("Oops!");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Inside try catch that was inside the finally.");
                }

                // Control cannot leave the body of a finally clause
                // return false;
            }

            // If the try or catch had a return statement, then
            // this would be unreachable code; otherwise, it would
            // be perfectly valid and reachable code.
            // return true;
        }
    }
}
