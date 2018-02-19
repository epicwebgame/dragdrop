using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace FirstExample
{
    // I wrote this program just to break the ice. I just wanted to implement and consume
    // a TAP method. Sadly, this I am running on the UI thread and this is the only one
    // method in the Call Stack, i.e., I am not calling an async method which calls another async
    // method and that calls another async method, I have to wait on the completion of this
    // GetStringLengthAsync method in the Main method.
    // I am very curious to see a few things:
    // 1. What transformations does the compiler do if I actually await an asynchronous method?
    // 2. In the caller, do I have to say:
    //    int result = await GetIntegerAsync(); // ? or what happens if I instead say
    //    Task<int> task = await GetIntegerAsync(); //? Is this even legal? I suspect not. Or if I instead said.
    //    Task<int> task = GetIntegerAsync(); // i.e., if I called it just like I would call any regular method. 
    //                                        But then I guess the compiler might complain that the calling method 
    //                                        must not be marked async in that case because it will have a tough time 
    //                                        figuring out the translation, which itself will be uncalled for in this case.
    // But if I did not mark the method async and called it like a regular method and got back
    // a Task<T>, what would I actually do with it? What *could* I do with it?
    // Call the TPL API myself, like, task.WaitOne() or something equivalant? In which case, 
    // I would be blocking the current thread.
    // Or I might say, task.ContinueWith(.../* a lambda representing the rest of the code */); // ? Hmm! That makes more sense.
    // That means I will be writing what the compiler might have done for me, by hand, by making calls into the
    // surface area of the TPL API.
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

        static Task<int> GetStringLengthAsync(string s)
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
                catch(Exception ex)
                {
                    source.SetException(ex);
                }
            }, null);

            return source.Task;
        }
    }
}