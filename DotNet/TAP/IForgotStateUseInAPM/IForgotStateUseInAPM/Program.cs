using System;

namespace IForgotStateUseInAPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = () => { Console.WriteLine("Hello"); };
            action.BeginInvoke(Callback, "State");
            Console.ReadKey();
        }

        static void Callback(IAsyncResult result)
        {
            var state = (string)result.AsyncState;
            Console.WriteLine(state);
            Console.WriteLine("Done");
        }
    }
}
