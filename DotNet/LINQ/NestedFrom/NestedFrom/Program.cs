using System;
using System.Linq;

namespace NestedFrom
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXAMPLE 1
            int[] first = { 1, 2, 3, 4 };
            int[] second = { 10, 11, 12, 13 };

            // First way
            var query = from n1 in first
                        from n2 in second
                        select n1 + n2;

            foreach (var n in query)
                Console.WriteLine(n);

            Console.WriteLine();

            // Second way
            foreach (var n1 in first)
                foreach (var n2 in second)
                    Console.WriteLine(n1 + n2);

            Console.WriteLine();

            // Third way
            var selectManyQuery = first.SelectMany(n => second, (n1, n2) => n1 + n2);

            foreach (var n in selectManyQuery)
                Console.WriteLine(n);



            // EXAMPLE 2
            var strings = new[] { "Hello, how are you?", "I am fine.", "How about you?", "Me, too. I am good." };

            // First way
            var stringQuery = from s in strings
                              from ch in s
                              select ch;

            foreach (var ch in stringQuery)
                Console.WriteLine(ch);

            Console.WriteLine();

            // Second way
            foreach (var s in strings)
                foreach (var ch in s)
                    Console.WriteLine(ch);

            Console.WriteLine();

            // Third way
            var selectManyStringsQuery = strings.SelectMany(s => s, (s, ch) => ch);

            foreach (var ch in selectManyStringsQuery)
                Console.WriteLine(ch);

            Console.ReadKey();
        }
    }
}
