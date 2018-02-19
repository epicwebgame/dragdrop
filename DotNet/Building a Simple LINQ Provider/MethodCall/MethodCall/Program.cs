using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MethodCall
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call a static method of this class
            // TestCallStaticMethodOfSameClass();
            
            // Call a static method of another class
            // TestCallStaticMethodOfAnotherClass();

            // Call an instance method of the same class
            // new Dog().CallBarkUsingLINQExpressionAPI();

            // Call an instance method of some class
            // TestCallInstanceMethodOfSomeClass();

            // Call a method with optional arguments
            // Provide a value for the optional argument
            // TestCallAMethodWithOptionalArgumentsProvidingAValue();

            // Call a method with optional arguments
            // but without providing any value for the optional arguments
            TestCallAMethodWithOptionalArgumentsWithoutProvidingAValue();

            Console.ReadKey();
        }

        static void TestCallAMethodWithOptionalArgumentsProvidingAValue()
        {
            var currentType = typeof(Program);

            var methodInfo = currentType.GetMethod("IAmAStaticMethodWithOptionalArguments", BindingFlags.NonPublic | BindingFlags.Static);

            var methodCallExpression =
                Expression.Call(null,
                methodInfo,
                Expression.Constant("Hello, World!", typeof(string)));

            methodCallExpression.Print();
        }

        static void TestCallAMethodWithOptionalArgumentsWithoutProvidingAValue()
        {
            var currentType = typeof(Program);

            var methodInfo = currentType.GetMethod("IAmAStaticMethodWithOptionalArguments", BindingFlags.NonPublic | BindingFlags.Static);

            var methodCallExpression = Expression.Call(null, methodInfo);

            methodCallExpression.Print();
        }

        static void IAmAStaticMethodWithAStringArgument(string arg)
        {
            Console.WriteLine("I am a static method. You gave me the argument '{0}'", arg);
        }

        static void IAmAStaticMethodWithOptionalArguments(string optional = "default value")
        {
            Console.WriteLine("I am a static method. I have an optional argument. Its value is '{0}'.", optional);
        }

        static void TestCallStaticMethodOfSameClass()
        {
            var currentType = typeof(Program);

            var methodInfo = currentType.GetMethod("IAmAStaticMethodWithAStringArgument", BindingFlags.NonPublic | BindingFlags.Static);

            var methodCallExpression =
                Expression.Call(null, 
                methodInfo,
                Expression.Constant("Hello, World!", typeof(string)));

            methodCallExpression.Print();
        }

        static void TestCallStaticMethodOfAnotherClass()
        {
            var dogType = typeof(Dog);

            var methodInfo = dogType.GetMethod("GetMaxAge", BindingFlags.Public | BindingFlags.Static);

            var methodCallExpression = Expression.Call(null, methodInfo);

            methodCallExpression.Print();
        }

        static void TestCallInstanceMethodOfSomeClass()
        {
            //var dog = new Dog();
            var dogExpression = Expression.Parameter(typeof(Dog), "dog");
            
            var dogAssignExpression = Expression.Assign(dogExpression,
                Expression.MemberInit(Expression.New(typeof(Dog)),
                Expression.Bind(typeof(Dog).GetProperty("Name"), Expression.Constant("Woofy"))));

            var methodInfo = typeof(Dog).GetMethod("Bark");

            Expression.Call(dogExpression, methodInfo).Print();
        }
    }

    class Dog
    {
        public string Name { get; set; }

        public void CallBarkUsingLINQExpressionAPI()
        {
            var methodInfo = GetType().GetMethod("Bark");
            Expression.Call(Expression.Constant(this), methodInfo).Print();
        }

        public void Bark()
        {
            Console.WriteLine("{0} is barking...");
        }

        public static int GetMaxAge()
        {
            return 20;
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
}
