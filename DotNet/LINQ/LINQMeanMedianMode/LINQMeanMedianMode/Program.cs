using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQMeanMedianMode
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User { Name = "A", Age = 12 },
                new User { Name = "B", Age = 20 },
                new User { Name = "C", Age = 56 },
                new User { Name = "D", Age = 12 },
                new User { Name = "E", Age = 10 }
            };

            // Mean: sum / n = 22
            var averageAge = users.Average(u => u.Age);
            Console.WriteLine($"Mean: {averageAge}");

            // Median : mid-value with equal values on each side = 12
            var n = users.Count();
            var sortedUsers = users.OrderBy(u => u.Age);
            int? median;
            var mid = (int)n / 2;
            if (n % 2 == 0)
            {
                median = (sortedUsers.ElementAt(mid - 1).Age + sortedUsers.ElementAt(mid).Age) / 2;
            }
            else
            {
                median = sortedUsers.ElementAt(mid).Age;
            }
            Console.WriteLine($"Median: {median}");

            // Mode: the value that occurs the most = 12
            var mode = users
                .GroupBy(u => u.Age)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
            Console.WriteLine($"Mode: {mode}");

            Console.ReadKey();
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}