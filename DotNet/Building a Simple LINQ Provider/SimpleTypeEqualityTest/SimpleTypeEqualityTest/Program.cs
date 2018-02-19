using System;

namespace SimpleTypeEqualityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Dog() is Dog);
            Console.WriteLine(new Dog() is PoodleDog);
            Console.WriteLine(new PoodleDog() is Dog);

            Console.WriteLine(new Dog().GetType() == typeof(Dog));
            Console.WriteLine(new Dog().GetType() == typeof(PoodleDog));
            Console.WriteLine(new PoodleDog().GetType() == typeof(Dog));

            Console.ReadKey();
        }
    }

    class Dog { }
    class PoodleDog : Dog { }
}