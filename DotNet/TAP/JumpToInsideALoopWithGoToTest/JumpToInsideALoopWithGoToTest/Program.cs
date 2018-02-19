using System;

namespace JumpToInsideALoopWithGoToTest
{
    // See my question: http://stackoverflow.com/q/37623035/303685
    // OR
    // http://stackoverflow.com/questions/37623035/isnt-it-illegal-c-sharp-code-to-jump-into-a-label-inside-a-loop-from-outside-th
    class Program
    {
        static int i = 0;
        static int someRandomNumber = 0;

        static void Main(string[] args)
        {


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static bool GoToInsideLoopTest(int howMany)
        {
            if (i == 0)
            {
                i = 1; return true;
            }

            if (i == 1)
            {
                while (someRandomNumber < howMany)
                {
                    i = 2;
                    return true;

                    Increment: i++;
                }
            }

            if (i == 2)
            {
                goto Increment;
            }

            return false;
        }
    }
}