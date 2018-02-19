using System;
using System.Linq.Expressions;

namespace LambdaToExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            // See my StackOverflow question about this here:
            // 

            // Why is this not possible?
            /// The compiler says:
            // Cannot convert lambda expression to type 'System.Linq.Expressions.LambdaExpression' because it is not a delegate type
            // LambdaExpression decrementorExpression = (i => i - 1);

            // When this is
            Expression<Func<int, int>> incrementorExpression = (i => i + 1);

            // And why is this not possible? The compiler, in this case, reports:
            // An expression tree may not contain an assignment operator
            // Expression<Func<int, int>> incrementExpression = (i => ++i);

            Console.ReadKey();
        }

        public Expression<Func<T>> ToExpression<T>(Func<T> func)
        {
            return func;
        }
    }
}
