using System;
using Dog;

namespace TestClassAndNamespaceSame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();

            Console.ReadKey();
        }
    }
}

namespace Dog
{
    class Dog { }
}
