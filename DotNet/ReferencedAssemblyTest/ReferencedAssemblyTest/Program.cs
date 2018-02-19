using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ReferencedAssemblyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test0();
               
            Console.ReadKey();
        }

        // This executing assembly references A and B.
        // Both A and B reference Lib.Base
        // Don't call anything
        // See which assemblies are returned by GetReferencedAssemblies
        // See which are loaded in the current app domain
        static void Test0()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var caller = GetCaller();
            stopwatch.Stop();
            Console.WriteLine($"GetCaller took {stopwatch.Elapsed.TotalMilliseconds} milliseconds");


            PrintReferencedAssemblies(Assembly.GetExecutingAssembly());

            PrintAssembliesLoadedInCurrentAppDomain();
        }

        static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }

        // Calls a method from A
        // References B but doesn't call a method from B
        // Both A and B reference Lib.Base
        // See which assemblies are returned by GetReferencedAssemblies
        // See which are loaded in the current app domain
        static void Test1()
        {
            var a = new Lib.A.Class1();
            var b = new Lib.B.Class1();

            a.Do();

            PrintReferencedAssemblies(Assembly.GetExecutingAssembly());

            PrintAssembliesLoadedInCurrentAppDomain();
        }

        private static void PrintReferencedAssemblies(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));

            var writer = new IndentedTextWriter(Console.Out);

            writer.WriteLine("Assembly.GetExecutingAssembly().GetReferencedAssemblies:");
            writer.Indent++;

            foreach(var asm in assembly.GetReferencedAssemblies())
            {
                writer.WriteLine($"* {asm.Name}");
            }

            writer.Indent--;
            writer.WriteLine();
        }

        private static void PrintAssembliesLoadedInCurrentAppDomain()
        {
            var currentDomain = AppDomain.CurrentDomain;
            var writer = new IndentedTextWriter(Console.Out);

            writer.WriteLine("AppDomain.CurrentDomain.GetAssemblies:");
            writer.Indent++;

            foreach (var asm in currentDomain.GetAssemblies())
            {
                writer.WriteLine($"* {asm.GetName().Name}");
            }

            writer.Indent--;
            writer.WriteLine();
        }

        // Call LoadLibrary or Assembly.Load to load C. C has Lib.Base as base class.
        // Call LoadLibrary or Assembly.Load to load D. D references no other.
        // See which assemblies are returned by GetReferencedAssemblies
        // See which are loaded in the current app domain
        static void Test2()
        {

        }

        // After running Test2, and consequently calling Assembly.Load for
        // C and D, are they still loaded in the current app domain and do they
        // still get returned by GetReferencedAssemblies?
        static void Test3()
        {

        }

        // foreach assembly in a certain directory (the bin)
        // get referenced assemblies for the top-level (just 1 level)
        // only
        static void Test4()
        {

        }

        // foreach assembly in a certain directory (the bin)
        // get referenced assemblies recursively
        static void Test5()
        {

        }

        // for each assembly referened by the
        // currently executing assembly, 
        // get referenced assemblies recursively
        static void Test6()
        {

        }
    }
}
