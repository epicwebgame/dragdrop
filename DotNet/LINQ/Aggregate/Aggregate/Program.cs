using System;
using System.Linq;

namespace Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new[] { 1, 2, 3, 4 };
            var aggregate = col.Aggregate((total, n) => total + n);

            // Expected output: 10
            Console.WriteLine(aggregate);

            var agg2 = col.Aggregate(12, (s, n) => s + n);

            // Expected output: 22
            Console.WriteLine(agg2);


            var agg3 = col.Aggregate(20, (s, n) => s + n, total => 2 * total);
            
            // Expected output: 60
            Console.WriteLine(agg3);

            Console.ReadKey();
        }
    }
}