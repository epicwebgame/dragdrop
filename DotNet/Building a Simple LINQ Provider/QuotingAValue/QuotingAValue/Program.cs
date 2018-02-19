using System;
using System.Linq.Expressions;

namespace QuotingAValue
{
    class Program
    {
        static void Main(string[] args)
        {
            QuotingIsNotFor();

            ConsiderThis();

            QuotingIsAlsoNotForButYouCanDoThis();

            Console.ReadKey();
        }

        private static void ConsiderThis()
        {
            var parameter = Expression.Parameter(typeof(int), "num");

            var lambda = Expression.Lambda<Func<int, bool>>(
                Expression.GreaterThan(parameter, Expression.Constant(1)), 
                parameter);

            Console.WriteLine(lambda.ToString());

            Console.WriteLine(lambda.Compile()(4));

            Console.WriteLine("***************\n");
        }

        private static void QuotingIsAlsoNotForButYouCanDoThis()
        {
            var parameter = Expression.Parameter(typeof(int), "num");

            var lambda = Expression.Lambda<Func<int, bool>>(
                Expression.GreaterThan(parameter, Expression.Constant(1)),
                parameter);

            var quotedLambdaAsUnary = Expression.Quote(lambda);

            // Quote
            Console.WriteLine("quotedLambdaAsUnary.NodeType: {0}", quotedLambdaAsUnary.NodeType);

            // Func<int, bool>
            Console.WriteLine("quotedLambdaAsUnary.Type: {0}", quotedLambdaAsUnary.Type);

            // UnaryExpression
            Console.WriteLine("quotedLambdaAsUnary.GetType(): {0}", quotedLambdaAsUnary.GetType());

            // null
            Console.WriteLine("quotedLambdaAsUnary.Method: {0}", quotedLambdaAsUnary.Method == null ? "null" : quotedLambdaAsUnary.Method.Name);

            // num => (num > 1)
            Console.WriteLine("quotedLambdaAsUnary.Operand.ToString(): {0}", quotedLambdaAsUnary.Operand.ToString());

            // Func<int, bool>
            Console.WriteLine("quotedLambdaAsUnary.Operand.Type: {0}", quotedLambdaAsUnary.Operand.Type);

            // Expression<Func<int, bool>>
            Console.WriteLine("quotedLambdaAsUnary.Operand.GetType(): {0}", quotedLambdaAsUnary.Operand.GetType());
            
            Console.WriteLine("***************\n");
        }

        static void QuotingIsNotFor()
        {
            try
            {
                var fourAsExpression = Expression.Constant(4);

                Console.WriteLine(fourAsExpression.ToString());

                var quotedFour = Expression.Quote(fourAsExpression);

                Console.WriteLine(quotedFour.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("***************\n");

        }
    }
}
