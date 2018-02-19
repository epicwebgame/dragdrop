using System;
using System.Linq;

namespace ArithmeticProgression
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 7, 12, 14, 8 };
            int accumulator = 0;
            var ap = numbers.Select(n => accumulator += n);

            foreach (var n in ap)
                Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}
