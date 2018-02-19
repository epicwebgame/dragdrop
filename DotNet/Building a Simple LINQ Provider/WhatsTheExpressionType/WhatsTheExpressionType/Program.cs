using System;
using System.Linq.Expressions;

namespace WhatsTheExpressionType
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryAddExpression = Expression.Add(Expression.Constant(1), Expression.Constant(10));

            Console.WriteLine("Node Type: {0}", binaryAddExpression.NodeType);
            Console.WriteLine("Type: {0}", binaryAddExpression.Type);

            Console.ReadKey();
        }
    }
}
