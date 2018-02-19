using System;

namespace CapturedVariables
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Dog
    {
        public void Bark(int howManyTimes)
        {
            Func<int> lambda = () => howManyTimes;

            lambda();
        }
    }
}