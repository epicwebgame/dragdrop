using System;
using System.Linq;

namespace AggregateAPGPHPFibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            // Also see this nice example as a use of the Aggregate function
            // https://msdn.microsoft.com/en-us/library/bb548744%28v=vs.100%29.aspx

            // Produce an AP. No, you don't *produce* anything using the Aggregate function.
            // You *aggregate* things.

            // Produce an AP anyway using something else
            var ap = Enumerable.Produce(1, 5, (seed, impact) => (seed + impact), 10);
            ap.Print("AP: ");

            // Find the sum of the AP using the Aggregate function
            var sumUsingAggregate = ap.Aggregate((a, n) => a + n);

            // Calculate the sum of the AP using the Sum() method
            var sumUsingSum = ap.Sum();

            // Calculate the sum of the AP using the formula 
            // Sum = n/2 { 2a + (n - 1)d }
            var first = ap.First();
            var apCount = ap.Count();
            var sumUsingFormula = (apCount / 2) * ((2 * first) + (apCount - 1) * 5);

            // Calculate the sum of the AP using the alternate formula
            // Since {a + (n - 1)d } is the last term of the AP, the
            // above formula can further be reduced to the following
            // Sum = n/2 { a + l } where l is the last term of the AP
            var last = ap.Last();
            var sumUsingAlternateFormula = (apCount / 2) * (first + last);

            // Assert that the 4 quantities are the same
            Console.WriteLine($"Sum of AP using Aggregate: {sumUsingAggregate}");
            Console.WriteLine($"Sum of AP using the Sum operator: {sumUsingSum}");
            Console.WriteLine($"Sum of AP using formula: {sumUsingFormula}");
            Console.WriteLine($"Sum of AP using alternate formula: {sumUsingAlternateFormula}");

            Console.WriteLine();


            // Produce a GP
            var gp = Enumerable.Produce(1, 5, (seed, impact) => (seed * impact), 10);
            gp.Print("GP: ");

            // Sum of the GP using Aggregate
            var sumOfGPUsingAggregate = gp.Aggregate((a, n) => a + n);

            // Sum of the GP using Sum
            var sumOfGPUsingSum = gp.Sum();

            // Sum of the GP using formula
            // Sum = a (r^n - 1) / (r - 1) if r > 1; and
            // Sum = a (1 - r^n) / (1 - r) if r < 1
            var firstElement = gp.First();
            var secondElement = gp.ElementAt(1);
            var r = secondElement / firstElement;
            var countOfGP = gp.Count();
            double sumOfGPUsingFormula;
            if (r > 1)
            {
                sumOfGPUsingFormula = (first * (Math.Pow(r, countOfGP) - 1)) / (r - 1);
            }
            else
            {
                sumOfGPUsingFormula = (first * (1 - Math.Pow(r, countOfGP))) / (1 - r);
            }

            // Assert that the quantities are the same
            Console.WriteLine($"Sum of GP using Aggregate: {sumOfGPUsingAggregate}");
            Console.WriteLine($"Sum of GP using Sum: {sumOfGPUsingSum}");
            Console.WriteLine($"Sum of GP using formula: {sumOfGPUsingFormula}");

            // Produce an HP

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
