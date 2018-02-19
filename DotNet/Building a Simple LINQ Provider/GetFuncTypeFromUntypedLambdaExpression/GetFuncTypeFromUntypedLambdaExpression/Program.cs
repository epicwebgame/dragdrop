using System;
using System.Linq.Expressions;

namespace GetFuncTypeFromUntypedLambdaExpression
{
    // This incited me to do this: http://stackoverflow.com/questions/16213005/how-to-convert-a-lambdaexpression-to-typed-expressionfunct-t
    // http://stackoverflow.com/q/16213005/303685
    // Seems like not possible unless the lambda is compiled as shown by the correct answer in that post
    class Program
    {
        static void Main(string[] args)
        {
            // TestCompilingUntypedLamda();

            TestGettingFuncType();

            Console.ReadKey();
        }

        static void TestCompilingUntypedLamda()
        {
            var paramExpression = Expression.Parameter(typeof(int), "i");

            var lambda = Expression.Lambda(
                Expression.MakeBinary(ExpressionType.GreaterThan, paramExpression, Expression.Constant(2)),
                paramExpression);

            lambda.Print();
            var func = lambda.Compile();
            var result = func.DynamicInvoke(10);
            Console.WriteLine(result);
        }

        static void TestGettingFuncType()
        {
            var paramExpression = Expression.Parameter(typeof(int), "i");

            var lambda = Expression.Lambda(
                Expression.MakeBinary(ExpressionType.GreaterThan, paramExpression, Expression.Constant(2)),
                paramExpression);

            System.Type funcType;
            var succcess = Expression.TryGetFuncType(new Type[] { typeof(int), typeof(bool) }, out funcType);
            if (succcess)
            {
                Console.WriteLine(funcType.ToString());
            }
            else
            {
                Console.WriteLine("Failed");
            }
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
