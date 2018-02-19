using System;

namespace IForgotHowClosuresAreImplemented
{
    /* I forgot how closures are implemented.I mean 
     * I remember -- I kind of remember that a separate 
     * class is created to capture the variables that are 
     * captured by the closure but I forgot if the lambda 
     * because of which the closure is created is also 
     * jettisoned out into this separate class, in effect, 
     * creating a separate scope of its own for itself and 
     * its closure / captured variables.

    Yes, I think my description / suspicion / remembrance above 
    is correct but I want to just test it and verify it for myself, 
    so I am just going to decompile this code in either Reflector 
    or IL Spy or ILDASM and see the C# v1.0 equivalent of the 
    decompiled code. 
    
    RESULTS:
    As expected, the decompilation process produces the following code:

   [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        // Fields
        public int x;

        // Methods
        internal int <Do>b__0(int n)
        {
            return (this.x * n);
        }
    }
    
    class Foo code for:
    Reflector -> View -> Options -> Disassembler -> Optimization -> .NET 1.0


    internal class Foo
    {
        // Methods
        public void Do()
        {
            <>c__DisplayClass0_0 CS$<>8__locals0 = new <>c__DisplayClass0_0();
            CS$<>8__locals0.x = 0;
            Func<int, int> func = new Func<int, int>(CS$<>8__locals0.<Do>b__0);
        }
    }
 

    class Foo code for:
    Reflector -> View -> Options -> Disassembler -> Optimization -> .NET 2.0 or above ( - .NET 4.0)
    internal class Foo
    {
        // Methods
        public void Do()
        {
            int x = 0;
            Func<int, int> func = delegate (int n) {
                return x * n;
            };
        }
    }

 
Collapse Methods
 


         
         */

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Foo
    {
        public void Do()
        {
            int x = 0;

            Func<int, int> func = n => x * n;
        }
    }
}
