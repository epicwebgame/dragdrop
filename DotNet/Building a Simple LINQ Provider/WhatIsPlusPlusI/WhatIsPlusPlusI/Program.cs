using System;

namespace WhatIsPlusPlusI
{
    class Program
    {
        static void Main(string[] args)
        {
            // See this StackOverflow question of mine:
            // http://stackoverflow.com/questions/27738944/where-is-the-implicit-cast-from-tdelegate-to-expressiontdelegate-declared
            // Same question link: http://stackoverflow.com/q/27738944/303685
            // Therefore, ++i actually means i = i + 1 and
            // not just (i + 1) as I thought for a while
            // Therefore, ++i is also an assignment operator
            // and is hence not allowed inside a lambda expression

            var i = 2;
            ++i;

            Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
