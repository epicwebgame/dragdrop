using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnwrapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Caller();
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void Caller()
        {
            var t = GetStringAsync();
            var continuation = t.ContinueWith(task => GetStringAsync());
            continuation.Unwrap().ContinueWith(task => GetStringAsync());
            Console.WriteLine(continuation.GetType().FullName);
        }

        static async Task<string> GetStringAsync()
        {
            return "Hello";
        }
    }
}
