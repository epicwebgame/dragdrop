using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APM1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("C:\\Sathyaish\\temp\\Movies\\AllMovies.txt", FileMode.Open))
            {
                byte[] b = new byte[1250];

                // var asyncResult = fs.BeginRead(b, 0, b.Length, CallMe, b);

                var asyncResult = fs.BeginRead(b, 0, b.Length, null, "Foo Async State");

                // while (!asyncResult.IsCompleted) ;

                asyncResult.AsyncWaitHandle.WaitOne();
                Console.WriteLine(asyncResult.AsyncWaitHandle.GetType().Name);
                Console.WriteLine(asyncResult.AsyncState);
                Console.WriteLine(ASCIIEncoding.ASCII.GetString(b));

                Console.WriteLine("The operation completed " + (asyncResult.CompletedSynchronously ? "synchronously" : "asynchronously"));
                fs.Close();
            }

            Console.ReadKey();
        }

        static void CallMe(IAsyncResult asyncResult)
        {
            byte[] bytes = (byte[])asyncResult.AsyncState;
            Console.WriteLine("File read. Contents are:");
            var contents = ASCIIEncoding.ASCII.GetString(bytes);
            Console.WriteLine(contents);
        }
    }
}
