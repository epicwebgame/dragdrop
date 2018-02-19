using System;
using System.Linq.Expressions;

namespace ConstantDefaultAndParameterExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            AssignMemoryToReferenceTypeVariable();
            
            Console.ReadKey();
        }

        static void TestConstantExpression()
        {
            ConstantExpression twoAsObject = Expression.Constant(2);
            ConstantExpression twoAsString = Expression.Constant("2", typeof(string));
            ConstantExpression twoAsInt = Expression.Constant(2, typeof(int));
            ConstantExpression twoAsDouble = Expression.Constant(2.0, typeof(double));

            twoAsObject.Print();
            twoAsString.Print();
            twoAsInt.Print();
            twoAsDouble.Print();
        }

        static void TestParameterExpression()
        {
            var nameParameterExpression = Expression.Parameter(typeof(string), "name");
            var ageParameterExpression = Expression.Parameter(typeof(int), "age");
            var dogParameterExpression = Expression.Parameter(typeof(Dog), "dog");
            var namelessParameterExpression = Expression.Parameter(typeof(bool));

            nameParameterExpression.Print();
            ageParameterExpression.Print();
            dogParameterExpression.Print();
            namelessParameterExpression.Print();
        }

        static void AssignValueToValueTypeVariable()
        {
            var ageVariableExpression = Expression.Parameter(typeof(int), "age");
            var ageAssignmentExpression = Expression.Assign(ageVariableExpression, Expression.Constant(10));

            var nameVariableExpression = Expression.Parameter(typeof(string), "name");
            var nameAssignmentExpression = Expression.MakeBinary(ExpressionType.Assign, nameVariableExpression, Expression.Constant("Woofy"));

            ageAssignmentExpression.Print();
            nameAssignmentExpression.Print();
        }

        static void AssignMemoryToReferenceTypeVariable()
        {
            var dogParameterExpression = Expression.Parameter(typeof(Dog), "dog");
            var newDogExpression = Expression.New(typeof(Dog));
            var assignExpression = Expression.Assign(dogParameterExpression, newDogExpression);

            dogParameterExpression.Print();
            newDogExpression.Print();
            assignExpression.Print();
        }

        static void TestDefaultExpression()
        {
            var defaultOfInt = Expression.Default(typeof(int));
            var defaultOfString = Expression.Default(typeof(string));
            var defaultOfObject = Expression.Default(typeof(object));
            var defaultOfDog = Expression.Default(typeof(Dog));

            // Just an idea, though not possible to invoke an open
            // generic type
            // var defaultOfT = Expression.Default(typeof(T));

            defaultOfInt.Print();
            defaultOfString.Print();
            defaultOfObject.Print();
            defaultOfDog.Print();
        }
    }

    public static class Extensions
    {
        public static void Print(this object o)
        {
            Console.WriteLine("Value: {0}, Expression Type: {1}, Type of value: {2}\n", o.ToString(), 
                o is Expression ? o.GetType().Name : "null",
                o is Expression ? (o as Expression).Type.Name : o.GetType().Name);
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}