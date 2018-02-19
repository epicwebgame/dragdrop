using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Block
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBlock();

            Console.ReadKey();
        }

        private static void TestBlock()
        {
            var paramExpression1 = Expression.Parameter(typeof(int), "i");
            var paramExpression2 = Expression.Parameter(typeof(string), "greeting");
            var parameterExpression3 = Expression.Parameter(typeof(bool), "success");
            var parameterExpression4 = Expression.Parameter(typeof(decimal), "salary");

            var variableList = new List<ParameterExpression> { parameterExpression3, parameterExpression4 };

            Expression<Func<int, int, int>> sumLambdaExpression = (x, y) => x + y;

            var invocationExpression = Expression.Invoke(sumLambdaExpression, Expression.Constant(1), Expression.Constant(2));

            var blockExpression = Expression.Block(variableList, invocationExpression, paramExpression1, paramExpression2);

            sumLambdaExpression.Print();
            invocationExpression.Print();
            blockExpression.Print();

            Console.WriteLine("Expressions in the block:");
            foreach (var exp in blockExpression.Expressions)
                exp.Print();

            Console.WriteLine("Variables in the expression:");
            foreach (var variable in blockExpression.Variables)
                variable.Print();

            var lambdaExpression = Expression.Lambda<Func<int, string, string>>(blockExpression, paramExpression1, paramExpression2);
            lambdaExpression.Print();

            var lambda = lambdaExpression.Compile();
            lambda.Print();

            var result = lambda(2, "Hello, World!");
            Console.WriteLine(result);
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