using System;
using System.Threading.Tasks;

namespace DoesTaskRunSignalCompletion
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Caller();
            var continuation = t.ContinueWith(task => { Console.WriteLine(task.Result); });
            continuation.Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<int> Caller()
        {
            var t = Called();
            while (!t.IsCompleted) ;
            return t.Result;
        }

        static async Task<int> Called()
        {
            return await Task.Run(() => 42);
        }
    }
}
