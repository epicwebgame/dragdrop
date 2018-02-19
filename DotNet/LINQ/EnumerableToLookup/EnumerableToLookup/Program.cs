using System;
using System.Linq;

namespace EnumerableToLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new [] { "Sathyaish", "Pramod", "Hari", "Rashmi", "Sonali", "Preeti", "Mukund", "Neelesh" };

            var lookup = people.ToLookup(s => s.ToUpper().First());

            foreach (var group in lookup)
            {
                Console.WriteLine($"{group.Key} ({group.Count()} names):");

                foreach(var s in group)
                {
                    Console.WriteLine($"\t{s}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
