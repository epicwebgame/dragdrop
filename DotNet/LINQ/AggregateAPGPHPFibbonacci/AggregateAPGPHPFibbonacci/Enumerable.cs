using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregateAPGPHPFibbonacci
{
    public static class Enumerable
    {
        public static IEnumerable<T> Produce<T>(T seed, T impact, Func<T, T, T> func, int count)
        {
            var result = seed;
            var list = new List<T>();
            list.Add(seed);

            for(int i = 0; i < count - 1; i++)
            {
                result = func(result, impact);
                list.Add(result);
            }

            return list;
        }

        public static void Print<T>(this IEnumerable<T> col, string prefix = null, string separator = ", ")
        {
            var strings = col.Take(col.Count() - 1)
                .Select(i => string.Format($"{i}{separator}"))
                .Concat(new List<string> { col.Last().ToString() });

            var s = string.Concat(prefix, strings.Aggregate((seed, next) => seed + next));

            Console.WriteLine(s);
        }
    }
}
