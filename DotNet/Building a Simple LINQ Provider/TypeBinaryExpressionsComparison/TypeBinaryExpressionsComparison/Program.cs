using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TypeBinaryExpressionsComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>{ "Hello", "World!" };

            Console.WriteLine("strings.GetType().Name: {0}", strings.GetType().Name);
            Console.WriteLine("strings is IEnumerable<string>: {0}", strings is IEnumerable<string>);
            Console.WriteLine("strings.GetType() == typeof(IEnumerable<string>): {0}", strings.GetType() == typeof(IEnumerable<string>));

            TypeBinaryExpression typeIsExpression = Expression.TypeIs(
                Expression.Constant("Hello"), typeof(IEnumerable<char>));

            TypeBinaryExpression typeEqualExpression = Expression.TypeEqual(
                Expression.Constant("Hello"), typeof(IEnumerable<char>));

            Console.WriteLine("\n\n");
            
            Console.WriteLine("typeIsExpression ({0}) value: {1}",
                typeIsExpression.ToString(),
                Expression.Lambda<Func<bool>>(typeIsExpression).Compile()());

            Console.WriteLine("typeEqualExpression {0} value: {1}", 
                typeEqualExpression.ToString(),
                Expression.Lambda<Func<bool>>(typeEqualExpression).Compile()());

            Console.ReadKey();
        }
    }
}
