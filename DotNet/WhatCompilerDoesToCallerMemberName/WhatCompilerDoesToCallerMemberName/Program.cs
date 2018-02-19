using System;
using System.Runtime.CompilerServices;

namespace WhatCompilerDoesToCallerMemberName
{
    class Program
    {
        // QUESTION:
        // I want to see what the compiler translates
        // the CallerMemberNameAttribute to, if anything.
        // I want to see how this works. Because getting the caller
        // name really should be a runtime thing. So does the C# compiler
        // do some transformation or is all that talk about the compiler
        // re-writing this talking about the JIT compiler? Even then,
        // it doesn't make sense.

        // ANSWER
        // Oh, neat! It changes the callsite. So,
        // unlike what I was thinking, it alters not the
        // called method's body but it alters the line in the
        // Main function that calls the Do() function making it
        // look like so:
        // Do("Main");
        static void Main(string[] args)
        {
            Do();
            Console.ReadKey();
        }

        static void Do([CallerMemberName] string caller = null)
        {
            Console.WriteLine($"Doing. We were called by {caller}.");
        }
    }
}
