using System;
using System.Linq.Expressions;
using System.Reflection;

namespace UnaryExpressions
{
    // Also see this question of mine: http://stackoverflow.com/questions/27792849/get-methodinfo-for-a-lambda-expression
    // http://stackoverflow.com/q/27792849/303685
    class Program
    {
        static void Main(string[] args)
        {
            // TestArrayLength();

            // TestConvert();

            // TestConvertChecked();

            // TestIncrement();

            TestUnbox();

            Console.ReadKey();
        }

        static void TestArrayLength()
        {
            var arrayExpression = Expression.NewArrayInit(typeof(string), 
                Expression.Constant("Hello"),
                Expression.Constant(", "),
                Expression.Constant("World"),
                Expression.Constant("!"));

            var arrayLengthUnaryExpression = Expression.ArrayLength(arrayExpression);

            arrayLengthUnaryExpression.Print();
        }

        static void TestConvert()
        {
            var intExpression = Expression.Constant(2);
            var convertExpression1 = Expression.Convert(intExpression, typeof(double));
            
            var methodInfo = typeof(Program).GetMethod("IntToString", BindingFlags.NonPublic | BindingFlags.Static,
                null, new Type[] { typeof(int) }, null);
            var convertExpression2 = Expression.Convert(intExpression, typeof(string), methodInfo);
            var convertExpression3 = Expression.Convert(intExpression, typeof(object));
            var convertExpression4 = Expression.Convert(intExpression, typeof(Program), 
                typeof(Program).GetMethod("IntToProgram", BindingFlags.NonPublic | BindingFlags.Static, 
                null, new Type[] { typeof(int) }, null));

            intExpression.Print();
            convertExpression1.Print();
            convertExpression2.Print();
            convertExpression3.Print();
            convertExpression4.Print();
        }

        static void TestConvertChecked()
        {
            var intExpression = Expression.Constant(2);
            var convertExpression1 = Expression.ConvertChecked(intExpression, typeof(double));

            var methodInfo = typeof(Program).GetMethod("IntToString", BindingFlags.NonPublic | BindingFlags.Static,
                null, new Type[] { typeof(int) }, null);
            var convertExpression2 = Expression.ConvertChecked(intExpression, typeof(string), methodInfo);
            var convertExpression3 = Expression.ConvertChecked(intExpression, typeof(object));
            var convertExpression4 = Expression.ConvertChecked(intExpression, typeof(Program),
                typeof(Program).GetMethod("IntToProgram", BindingFlags.NonPublic | BindingFlags.Static,
                null, new Type[] { typeof(int) }, null));

            Expression<Func<int, Dog>> conversionExpression = i => GetNewDog(i);
            var methodCallExpression = (MethodCallExpression)conversionExpression.Body;
            var convertExpression5 = Expression.ConvertChecked(intExpression, typeof(Dog), 
                methodCallExpression.Method);

            Func<int, Dog> conversionExpression2 = i => GetNewDog(i);
            var convertExpression6 = Expression.ConvertChecked(intExpression, typeof(Dog),
                conversionExpression2.Method);

            intExpression.Print();
            convertExpression1.Print();
            convertExpression2.Print();
            convertExpression3.Print();
            convertExpression4.Print();
            convertExpression5.Print();
            convertExpression6.Print();
        }

        static string IntToString(int i)
        {
            return i.ToString();
        }

        static Program IntToProgram(int i)
        {
            return new Program();
        }

        static Dog GetNewDog(int i)
        {
            return new Dog();
        }

        static void TestIncrement()
        {
            var intExpression = Expression.Constant(2);
            var incrementExpression = Expression.Increment(intExpression);
            intExpression.Print();
            incrementExpression.Print();
            intExpression.Print();

            var decrementExpression = Expression.Decrement(intExpression);
            decrementExpression.Print();
            intExpression.Print();
        }

        static void TestUnbox()
        {
            var objectExpression = Expression.Constant(2, typeof(object));
            var unboxExpression = Expression.Unbox(objectExpression, typeof(int));
            unboxExpression.Print();
        }
    }

    class Dog { }

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