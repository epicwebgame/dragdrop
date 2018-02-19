using Lib;
using System;

namespace Client
{
    // https://github.com/Reactive-Extensions/Rx.NET/issues/234
    // I am trying to test this scenario.
    // This client project namely, Client, will reference a binary (and not the project) of the Lib project. The binary
    // version will be 2.0.0. However, it will have a copy of the debug symbols of an old version v1.0.0.0 of the Lib
    // assembly. The intention is to see whether or not the debugger reports a mismatch between the debug symbols and
    // the loaded library.
    
    // As expected, the image and the PDB version have to match. For test results, please see the folder
    // named TestResults in the solution folder.
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            foo.Name = "Name";
            foo.NewProperty = "New Property";

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
