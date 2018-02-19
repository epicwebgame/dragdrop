using System;

namespace CompilerDoesNotCareAboutTypeLINQQuerySyntax
{
    class Program
    {
        static void Main(string[] args)
        {

            // What are the minimum requirements on Foo<T>()?
            // How does it resolve this expression new Foo<string>
            // such that it knows that Foo<string> has many Bar<string>
            // or whatever foo in the query below might resolve to?
            var query = from foo in new Foo<string>()
                        where foo.Name.StartsWith("S")
                        select new Foo<int>();

            Console.WriteLine(query.GetType().FullName);

            Console.ReadKey();
        }
    }

    public class Foo<T>
    {
        public string Name { get; set; }

        public Foo<T> Where(Func<Foo<T>, bool> predicate)
        {
            return new Foo<T>();
        }
    }

    public static class Extensions
    {
        public static Foo<R> Select<T, R>(this Foo<T> foo, 
            /* Func<T, R> transformer, 
            Though this is what you normally do in LINQ pipelines built on IEnumerable<T>
            it is not suitable here. It doesn't make sense here. So, we will do:
            */
            Func<Foo<T>, Foo<R>> transformer)
        {
            return transformer(foo);
        }
    }
}
