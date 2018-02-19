using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 7, 9, 18, 76 };

            var query = numbers.Where(number => number % 3 == 0);
                

            foreach (var thing in query)
                Console.WriteLine(thing);


            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static bool Any<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (var t in source)
                if (predicate(t))
                    return true;

            return false;
        }

        public static IEnumerable<T> WhereBad<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            var list = new List<T>();

            foreach (var t in source)
                if (predicate(t))
                    list.Add(t);

            return list;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            return new Foo<T>(source, predicate);
        }
    }

    public class Foo<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private Func<T, bool> _predicate;

        public Foo(IEnumerable<T> source, Func<T, bool> predicate)
        {
            _source = source;
            _predicate = predicate;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class FooEnumerator : IEnumerator<T>
    {
        public T Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
