using System;
using System.Linq;

namespace Zip
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new[] { 1, 2, 3, 4 };
            var second = new[] { 10, 11, 12, 13 };

            var query = first.Zip(second, (f, s) => f + s);

            // Expected output: 
            // 11, 13, 15, 17
            foreach (var n in query)
                Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}
