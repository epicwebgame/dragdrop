using System;

namespace ControlRMToRefactorCodeIntoAMethod
{
	// See https://app.pluralsight.com/player?course=csharp-6-whats-new&author=scott-allen&name=csharp-6-whats-new-m4&clip=3&mode=live
    class Program
    {
        static void Main(string[] args)
        {
            // Fuck! I didn't know this until just now.
            // If you select a bunch of code and type Ctrl + R + M
            // you can refactor that code into a method.
            // I got to know this by watching "What's new in C# 6"
            // a pluralsight course by Scott Allen
            // Go ahead! Select this blob of code, type Ctrl + R + M
            // and see what happens! Cool! Blew me away!
            var collection = new[] { string.Empty };

            foreach (var item in collection)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
