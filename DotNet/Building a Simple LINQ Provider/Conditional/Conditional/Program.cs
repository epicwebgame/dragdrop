using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Conditional
{
    class Program
    {
        static void Main(string[] args)
        {
            TestConditional();

            Console.ReadKey();
        }

        static void TestConditional()
        {
            // Remember, there is no cast from TDelegate to Expression<TDelegate>
            // http://stackoverflow.com/questions/27738944/where-is-the-implicit-cast-from-tdelegate-to-expressiontdelegate-declared
            // http://stackoverflow.com/q/27738944/303685
            //var paramExpression = Expression.Parameter(typeof(string), "s");
            //Action<string> printer = (s) => Console.WriteLine(s);
            //Expression<Action<string>> printerExpression = Expression.Lambda(printer, paramExpression);

            // A lambda expression with a statement body cannot be converted to an expression tree
            // Expression<Func<string, string>> printerExpression = (s) => { Console.WriteLine(s); return s; };

            var conditionalExpression = Expression.Condition(
                Expression.MakeBinary(ExpressionType.GreaterThan, Expression.Constant(4), Expression.Constant(2)),
                Expression.Call(null, typeof(Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null),
                Expression.Constant("4 is greater than 2")),
                Expression.Call(null, typeof(Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null),
                Expression.Constant("2 is greater than 4")));

            conditionalExpression.Print();
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
