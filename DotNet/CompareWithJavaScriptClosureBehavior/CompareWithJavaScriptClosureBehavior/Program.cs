using System;
using System.Threading;

namespace CompareWithJavaScriptClosureBehavior
{
    // See the JavaScript code snippet at about 8:40 in this video:
    // https://www.youtube.com/watch?v=KRm-h6vcpxs
    // Video Title: JavaScript: Getting Closure, by Mark Dalgleish (at the WebDirections code event or some such)
    // I am trying to compare the behavior of closures as they are implemented in JavaScript with that of their
    // implementation in C#. This idea to compare these two implementations has crossed my mind on several ocassions
    // in the past and I can't remember the results but I vaguely recall that I have done this comparison in the past as
    // well but since I can't remember the assimilation very clearly, I am trying to bring up the idea again, experiment
    // with it again, observe the behavior and this time form a somewhat permanent memory of the differences in the two
    // behaviors
    // The JavaScript code snippet is roughly like this:
    // for (var i = 0; i <= 3; i++)
    // {
    //      // Produces 4, 4, 4, 4
    //      // and not 1, 2, 3 and 4
    //      something.click = function() { alert(i); };
    // }
    class Program
    {
        static void Main(string[] args)
        {
            var button = new Button();

            for(int i = 0; i < 4; i++)
            {
                button.Click += () => { Console.WriteLine($"Button clicked: {i}"); };
            }

            // Some time passes
            Thread.Sleep(500);

            // The variable i is declared inside the for loop
            // Since C# has block scope, uncommenting the following line
            // should result in a compilation error, which it does.
            // Console.WriteLine(i);

            // The question is: "when" is the 'i' captured?
            // At what point in time. I understand "how" it is
            // captured. What now needs to be examined is "when."
            // And how does that 'i' get from there (the block scope
            // which clearly is not "alive" at this point) to here?
            // Basically, an answer to "when" the scope or the closure
            // is obtained over 'i' will answer this question too. This question
            // is a part of the first question.
            button.Click();

            // Interestingly, the C# code also exhibits the same behavior as that of 
            // Java. And in an answer to the question of "when the closure is captured,"
            // we must examine the C# compiler generated code for this program. The relevant
            // bits are produced below.
            /* 
                [CompilerGenerated]
                private sealed class <>c__DisplayClass0_0
                {
                    public int i;

                    internal void <Main>b__0()
                    {
                        Console.WriteLine(string.Format("Button clicked: {0}", this.i));
                    }
                }

                internal class Program
                {
                    public static void ButtonClickHandler()
                    {
                        Console.WriteLine("Button clicked");
                    }

                    private static void Main(string[] args)
                    {
                        Button button = new Button();
                        <>c__DisplayClass0_0 CS$<>8__locals0 = new <>c__DisplayClass0_0();
                        CS$<>8__locals0.i = 0;
                        while (CS$<>8__locals0.i < 4)
                        {
                            button.Click = (Action) Delegate.Combine(button.Click, new Action(CS$<>8__locals0.<Main>b__0));
                            int i = CS$<>8__locals0.i;
                            CS$<>8__locals0.i = i + 1;
                        }
                        Thread.Sleep(500);
                        button.Click();
                        Console.ReadKey();
                    }
                }
             */

            // As is evident from the snippet above, only one instance of the class generated
            // to represent the closure is created. And that makes sense the purpose of that class
            // is to embody a method and not necessarily different "states" at different points in time
            // but simply to capture the state "at a single point in time." Therefore, there is only
            // "an instance field" publicly available through the public access specifier.
            // The for loop inside the Program.Main() method simply increments this public field
            // name 'i' every time, leaving it with the value 4 at the end of the last iteration.
            // Hence, when it is finally called by the invocation of the Click delegate instance
            // even though there are four distinct method calls in the invocation list, they all
            // point to a shared method that resides within a single instance, and most importantly,
            // the methods are invoked on the same object instance, hence sharing the captured variable
            // 'i' for each invocation.

            // Now, let's try it with the solution that JavaScript offers, which is
            // to execute an iffy (Immediately Fired Function Expression) which accepts
            // the state as a parameter and to have the body of the for loop inside that iffy.
            // The JavaScript version is this:
            // 
            // for(var i = 0; i <= 3; i++)
            // {    
            //      (function(i)
            //      {
            //          something.Click(function() { makeAlert(i); });
            //      })(i);
            // }
            // Let me try something similar in C#:
            for (int i = 0; i < 4; i++)
            {
                // Oops! I can't. We cannot immediately execute lambdas.
                // Can we?
                //((i) =>
                //{
                //    // No. We can't. I recall there was a Channel 9 interview
                //    // where someone asked this of Anders Hejlsberg
                //    // as to why we don't have iffy's in C# and he said
                //    // that that was a conscious decision. C# is a complicated
                //    // beast and they think a lot before adding any new feature.
                //    // In contrast, JavaScript was something Brendon Eich blurted
                //    // out at gun-point in a week's time.
                //})();
            }
            
            Console.ReadKey();
        }

        public static void ButtonClickHandler(int i)
        {
            Console.WriteLine($"Button clicked: {i}");
        }
    }

    class Button
    {
        public Action Click { get; set; }
        public Action<int> DoubleClick { get; set; }
    }
}