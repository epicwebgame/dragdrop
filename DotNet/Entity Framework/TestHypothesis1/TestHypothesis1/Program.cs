using ClassLibrary1;
using System;

namespace TestHypothesis1
{
    class Program
    {
        // Testing the hypothesis presented in this answer: http://stackoverflow.com/a/38130945/303685
        // This seems to be the behavior with just (or may be even others I haven't tested for)
        // IDisposable.
        // anotherFoo instance is created just fine, but the moment I uncomment
        // the using statement code, it shrieks.

        // Final update:
        // The trigger for the error seems to be the call to the Dispose method and not
        // particularly the implementation of the using statement, which apparently, simply
        // ensures that Dispose is called, as is also well-known and documented.
        static void Main(string[] args)
        {
            //using (var foo = new Foo())
            //{
            //    foo.Gar = "Gar";

            //    Console.WriteLine(foo.Gar);
            //}

            var anotherFoo = new Foo() { Gar = "Another gar" };
            Console.WriteLine(anotherFoo.Gar);

            anotherFoo.Dispose();

            Console.ReadKey();
        }
    }
}
