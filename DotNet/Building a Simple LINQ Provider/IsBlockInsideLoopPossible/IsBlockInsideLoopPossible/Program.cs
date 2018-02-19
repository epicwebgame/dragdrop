using System;
using System.Linq.Expressions;

namespace IsBlockInsideLoopPossible
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestCanHaveEmptyBlock();

            TestBlockInsideLoop();

            Console.ReadKey();
        }

        private static void TestCanHaveEmptyBlock()
        {
            // No can do
            var blockExpression = Expression.Block();
            blockExpression.Print();
        }

        private static void TestBlockInsideLoop()
        {
            // Trying to generate this:
            //int x, y;

            //while(true)
            //{
            //    // block starts here
            //    if (++x > y)
            //        return x;
            //}
            
            var paramX = Expression.Parameter(typeof(int), "x");
            var paramY = Expression.Parameter(typeof(int), "y");

            LabelTarget returnLabelTarget = Expression.Label(typeof(int), "returnLabel");

            var conditional = Expression.Condition(Expression.MakeBinary(ExpressionType.GreaterThan, paramX, paramY), Expression.Return(returnLabelTarget, paramX), Expression.Continue(Expression.Label(typeof(void))));
            var blockExpression = Expression.Block(conditional, Expression.Default(typeof(int)));

            var loopExpression = Expression.Loop(blockExpression);

            Expression<Func<int, int, int>> lambdaExpression = Expression.Lambda<Func<int, int, int>>(
                loopExpression, paramX, paramY);

            paramX.Print();
            paramY.Print();
            returnLabelTarget.Print();
            conditional.Print();
            blockExpression.Print();
            loopExpression.Print();
            // lambdaExpression.Print();
        }

        private static void TestLoopInsideBlock()
        {
            // Trying to generate this:

            // block starts here
            //int x, y;

            //while (true)
            //{
            //    if (++x > y)
            //        return x;
            //}
            
            var paramX = Expression.Parameter(typeof(int), "x");
            var paramY = Expression.Parameter(typeof(int), "y");

            var blockExpression = Expression.Block();
            blockExpression.Print();
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
