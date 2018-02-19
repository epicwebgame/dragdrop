using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MemberExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var propertyExpression = Expression.MakeMemberAccess(Expression.Constant(new Dog()), typeof(Dog).GetProperty("Name"));

            var fieldInfo = typeof(Dog).GetField("_logger", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            var fieldExpression = Expression.MakeMemberAccess(Expression.Constant(new Dog()), fieldInfo);

            propertyExpression.Print();
            fieldExpression.Print();

            Console.ReadKey();
        }
    }

    public class Dog
    {
        private object _logger;

        public string Name { get; set; }
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