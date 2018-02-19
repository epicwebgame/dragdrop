using System;
using System.Linq.Expressions;

namespace Invocation
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInvocation();

            Console.ReadKey();
        }

        private static void TestInvocation()
        {
            Expression<Func<int, int, int>> sumLambdaExpression = (x, y) => x + y;
            var invocationExpression = Expression.Invoke(sumLambdaExpression, Expression.Constant(1), Expression.Constant(2));
            sumLambdaExpression.Print();
            invocationExpression.Print();
        }
    }

    public static class Extensions
    {
        public static void Print(this object o)
        {
            Console.WriteLine("Value: {0}, {1}, {2}\n", o.ToString(),
                o is Expression ? o.GetType().Name : "null",
                o is Expression ? (o as Expression).Type.Name : o.GetType().Name);
        }
    }
}
