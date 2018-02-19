using System;
using System.Collections.Generic;
using System.Linq;

namespace DoesIteratorStateMachineHaveIllegalCSharpCode
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var num in GetIntegers(5))
                Console.Write($"{num} ");

            Console.ReadKey();
        }

        static IEnumerable<int> GetIntegers(int until)
        {
            foreach (var value in Enumerable.Range(1, until))
                yield return value;
        }
    }
}
