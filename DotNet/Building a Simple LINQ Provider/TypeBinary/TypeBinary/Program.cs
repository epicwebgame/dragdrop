using System;
using System.Linq.Expressions;

namespace TypeBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTypeBinary();

            Console.ReadKey();
        }

        static void TestTypeBinary()
        {
            var stringExpression = Expression.Constant("I am a string", typeof(string));
            var ageExpression = Expression.Parameter(typeof(int), "age");

            var firstDogExpression = Expression.Constant(new Dog() { Name = "First Dog", Age = 7 });

            // Initialized memory but not initialized members
            var secondDogExpression = Expression.Parameter(typeof(Dog), "secondDog");
            var secondDogAssignmentExpression = Expression.Assign(secondDogExpression, Expression.New(typeof(Dog)));

            var thirdDogExpression = Expression.Parameter(typeof(Dog), "thirdDog");
            var thirdDogAssignmentExpression = Expression.Assign(thirdDogExpression, 
                Expression.MemberInit(Expression.New(typeof(Dog)), 
                Expression.Bind(typeof(Dog).GetProperty("Name"), Expression.Constant("Third Dog")), 
                Expression.Bind(typeof(Dog).GetProperty("Age"), Expression.Constant(7))));

            stringExpression.Print();
            ageExpression.Print();
            firstDogExpression.Print();
            secondDogExpression.Print();
            secondDogAssignmentExpression.Print();
            thirdDogExpression.Print();
            thirdDogAssignmentExpression.Print();

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");

            // Type Binary
            Expression.TypeIs(stringExpression, typeof(string)).Print();
            Expression.TypeIs(stringExpression, typeof(Dog)).Print();
            Expression.TypeIs(firstDogExpression, typeof(Dog)).Print();
            Expression.TypeIs(secondDogExpression, typeof(Dog)).Print();
            Expression.TypeIs(thirdDogExpression, typeof(Dog)).Print();

            // Type Binary
            Expression.TypeEqual(stringExpression, typeof(string)).Print();
            Expression.TypeEqual(stringExpression, typeof(Dog)).Print();
            Expression.TypeEqual(firstDogExpression, typeof(Dog)).Print();
            Expression.TypeEqual(secondDogExpression, typeof(Dog)).Print();
            Expression.TypeEqual(thirdDogExpression, typeof(Dog)).Print();

            // Unary
            Expression.TypeAs(stringExpression, typeof(string)).Print();
            Expression.TypeAs(stringExpression, typeof(Dog)).Print();
            Expression.TypeAs(firstDogExpression, typeof(Dog)).Print();
            Expression.TypeAs(secondDogExpression, typeof(Dog)).Print();
            Expression.TypeAs(thirdDogExpression, typeof(Dog)).Print();

            var paramD = Expression.Parameter(typeof(Dog), "d");
            var lambda = Expression.Lambda(Expression.TypeIs(paramD, typeof(Dog)), paramD);
            lambda.Print();
            Console.WriteLine(lambda.Compile());
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

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}