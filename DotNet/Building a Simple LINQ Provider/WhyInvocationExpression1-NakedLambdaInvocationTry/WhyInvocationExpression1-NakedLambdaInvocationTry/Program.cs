using System;

namespace WhyInvocationExpression1_NakedLambdaInvocationTry
{
    class Program
    {
        static void Main(string[] args)
        {
            // While one may write this
            Func<int, int> incrementor = (i => ++i);
            Console.WriteLine(incrementor(9));

            // One cannot do this in C#
            // Console.WriteLine((i => i++)(9));

            Console.ReadKey();
        }
    }
}
