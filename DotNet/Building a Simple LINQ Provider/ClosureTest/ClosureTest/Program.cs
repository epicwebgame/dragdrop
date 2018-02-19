using System;
using System.Linq;

namespace ClosureTest
{
    class Program
    {
        static Func<int, int> getInt = null;

        static void Main(string[] args)
        {
            ShortLivedMethod();

            // Notice that the ShortLivedMethod has long been
            // executed and its own local variable named local
            // is no longer in scope
            // what the closure is is a captured copy of
            // that variable with its state as it was when
            // ShortLivedMethod was executed.
            var result = getInt(2);
            
            // Should print 7, i.e. 2 + 5
            // The local is captured after the stack of the 
            // metehod or context from which the variable is captured
            // is being de-allocated or cleaned up, i.e. after all
            // statements in the method or context have been executed.
            Console.WriteLine(result);

            var dummy = new Dummy();
            var func = dummy.GetLambda();
            result.Times(dummy.Increment);
            dummy = null;
            
            // Dummy has been marked for garbage collection and 
            // hence the reference must be invalid. Therefore, the variable
            // Dummy.classLevelVariable must not exist. However, we must
            // see that the lambda, if it captures class level variables (which
            // is what I want to test because I forgot. One time I tested it and it
            // did not capture class-level varaibles in C#, but let's see again)
            // must have made a copy of the classLevelVariable.
            // The question then arises, "When? When must it have made the copy? At what
            // point in the life of the class?" That's interesting. I am thinking
            // this won't compile, but let's see.
            Console.WriteLine(func());

            Console.ReadKey();
        }

        static void ShortLivedMethod()
        {
            int local = 4;

            getInt = x => x + local;

            local++;
        }
    }

    class Dummy
    {
        int classLevelVariable = 1;

        public void Increment()
        {
            classLevelVariable++;
        }

        public Func<int> GetLambda()
        {
            return () => classLevelVariable;
        }
    }

    public static class Extensions
    {
        public static void Times(this int times, Action action)
        {
            for (int i = 0; i < times; action(), i++) ;
        }

        public static void Times(this long times, Action action)
        {
            for (int i = 0; i < times; action(), i++) ;
        }
    }
}
