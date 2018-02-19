using System;
using System.Text;

// 1. Is it necessary to call EndXXX()? Why? What does that method do?
//    Yes, it is necessary to call EndXXX() because it gives you back 
//    the result of the operation. Think of that as the return value of 
//    the method if the method were implemented as a synchronous operation.
//    Of course, if you do not care about the return value of the method
//    then there is no need to call EndXXX(). The thing is -- you are not
//    forced to or obliged to call EndXXX() but it is a recommended practice
//    and the only way to get to the return value of the method and in most
//    cases, you want the return value of the method.

// 2. All the possible ways I could implement an APM API. They are done below. 
//    There could be more ways I can't be bothered to think of right now.

// 3. Remember, when calling BeginXXX(), I could either pass a callback or use 
//    the IAsyncResult to wait for the operation to complete. Either one works just fine. 
//    Jeffrey Richter, in one of the Channel 9 videos, specifically the one interview titled, 
//    "AppFabric TV: Threading with Jeffrey Richter" recommends that we throw away the 
//    IAsyncResult return value and just the callback, but I suspect his remark was 
//    more of a "you can also do this" rather than a suggestion.
//    https://channel9.msdn.com/Shows/AppFabric-tv/AppFabrictv-Threading-with-Jeff-Richter

// As this article illustrates, you may get the return value in one of four ways:
// https://msdn.microsoft.com/en-us/library/2e08f6yc%28v=vs.110%29.aspx
// Title: Calling Synchronous Methods Asynchronously

// 1. Wait on the AsyncWaitHandle that's inside the IAsyncResult object.

// 2. Poll the IAsyncResult's IsCompleted property until it becomes true. This costs a busy-wait.

// 3. Call EndInvoke from the thread that called BeginInvoke itself.

// 4. Call EndInvoke from the callback you supplied to BeginInvoke.However, remember, 
//    due to the AsyncCallback signature restriction on the callback method, it 
//    cannot return a value, therefore the value it gets as the return value by 
//    calling the EndInvoke method must be passed back to the caller of the BeginInvoke 
//    method only via some bespoke implementation of the IAsyncResult class. When doing a 
//    bespoke implementation, however, although you may directly implement IAsyncResult, 
//    I noticed that there is a class named AsyncResult in the System.Remoting.Messaging 
//    namespace in mscorlib itself, which has a handy property named AsyncDelegate, which 
//    retains a reference to the delegate object on which BeginInvoke was called. 
//    This obviates the need for the caller of BeginInvoke to also store the receiver 
//    delegate instance of the BeginInvoke call in a class-level variable or in a local 
//    variable that may then need to be passed to the AsyncCallback function.Thus, when 
//    implementing a bespoke IAsyncResult, it will be nicer to inherit from 
//    System.Remoting.Messaging.AsyncResult instead of directly implementing the 
//    IAsyncResult interface.

namespace ImplementAPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        static void PrintRandomStrings(int howMany)
        {
            if (howMany == 0) return;

            int minAscii = 97, maxAscii = 97 + 26;
            int minLen = 2, maxLen = 9;
            var random = new Random(howMany);

            for(int i = 0; i < howMany; i++)
            {
                var len = random.Next(minLen, maxLen);
                var builder = new StringBuilder();

                for (int j = 0; j < len; j++)
                {
                    var c = (char)random.Next(minAscii, maxAscii + 1);
                    builder.Append(c);
                }

                builder.Append(" ");
                Console.Write(builder.ToString());
            }
        }

        static IAsyncResult BeginPrintRandomStrings(AsyncCallback callback, object state, int howMany)
        {
            // Delegate.BeginInvoke
            Action<int> caller = PrintRandomStrings;
            return caller.BeginInvoke(howMany, callback, state);
        }

        static void EndPrintRandomStrings(IAsyncResult result)
        {
        }

        static string ReadFile(string path)
        {
            return null;
        }

        static IAsyncResult BeginReadFile(string path, AsyncCallback callback, object state)
        {
            // t = new Thread

            return null;
        }

        static string EndReadFile(IAsyncResult result)
        {
            return null;
        }

        static void WriteToFile(string path, string text)
        {

        }

        static IAsyncResult BeginWriteToFile(string path, string text, AsyncCallback callback, object state)
        {
            // QueueUserWorkItem

            return null;
        }

        static void EndWriteToFile(IAsyncResult result)
        {

        }
    }
}