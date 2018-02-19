using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace SeeCompilerBasicTransformationForAwait
{
    // I am very curious to see a few things:
    // 1. What transformations does the compiler do if I actually await an asynchronous method?
    class Program
    {
        static void Main(string[] args)
        {
            var length = GetStringLengthAsync("Hello, World!").Result;
            Console.WriteLine($"Length of the string is {length}.");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static int GetStringLength(string s)
        {
            return s.Length;
        }

        // As soon as I put the async keyword in this method
        // declaration, two things pop up:
        // 1. The compiler reports an error at the line where I return source.Task.
        //    It says: Since this is an async method, the return expression must be of type 'int' rather than 'Task<int>'.
        //    Hmm! Interesting. What that means is: the async word is a trigger to tell the compiler
        //    "Hey, look! Take this method and subvert / invert its structure and do what you will so that
        //     when it is called, if it has an await inside it, then execute it such that the calling thread
        //     immediately returns after encoutering that await and comes back the next time this task is scheduled
        //     by the task scheduler and a thread (could be the same one that ran previously till the await or a different one altogether)
        //     running the rest of this code gets a slice of the CPU time. If there is no await keyword, however, I will let you
        //     get by with that so long as you write the code that "makes it asynchronous", i.e. some code that yields back to the CPU
        //     as in this case, I have manually called Delegate.Invoke to schedule the thread on a thread pool thread. However, if you
        //     do the asynchrony yourself, then you also return the return value yourself. That is, don't return a Task<T>. Instead, be
        //     responsible for returning the T itself, since you are taking control of asynchrony, ending the operation, being notified
        //     of the end of the operation and getting the result yourself, so you have the result, then you return it.
        // 2. The other thing that pops up is a warning, a green squiggly under the name of the method. This warning reads:
        //    The async method lacks 'await' operators and will run synchronously. Consider using the await operator to await non-blocking
        //    API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        //    This basically means the same thing. The compiler is saying, "Dude, I'll run this code but just like any other normal
        //    method. I won't do my magic because you are not using the magic trigger await, which tells me to do the transformation.
        //    Therefore, you be responsible for the transformation. I will run this method just like any other, and if you happen to have
        //    taken control of the asynchrony and implemented it yourself in this method's body, then so be it; the asynchrony will happen
        //    only because you wrote it. Whatever you wrote will happen.

        // But this could lead to a potential race condition, right?
        // We could return from this method without the callback that means task completion having being called
        // or worse yet without even the BeginInvoke having started on the thread pool. Hmm!
        // No, it won't lead to the race condition because calling Task.Result blocks the current
        // thread until the Task resolves to its result. Therefore, while no race condition may occur
        // this will potentially execute this particular method synchronously although the delegate
        // BeginInvoke will execute asynchronously. This looks like some wierd permutation. Best to stick
        // to the compiler generated transformations or to not mark a method async and just return the Task<T> object.
        static async Task<int> GetStringLengthAsync(string s)
        {
            TaskCompletionSource<int> source = new TaskCompletionSource<int>();
            Func<string, int> func = GetStringLength;

            var asyncResult = func.BeginInvoke(s, (ar) =>
            {
                try
                {
                    var lasyncResult = (AsyncResult)ar;
                    var del = (Func<string, int>)lasyncResult.AsyncDelegate;
                    var result = del.EndInvoke(ar);
                    source.SetResult(result);
                }
                catch (Exception ex)
                {
                    source.SetException(ex);
                }
            }, null);

            // return source.Task;
            return source.Task.Result;
        }
    }
}