using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SecondExample
{
    // I really want to see what transformation the compiler
    // does when I say:
    // await webClient.DownloadDataAsync("url");
    //
    // And then I also wanted to see how else I may write a method
    // that returns a Task<T> so I wrote different versions of the
    // GetData method.
    class Program
    {
        static void Main(string[] args)
        {
            var task = GetData("http://sathyaish.net");
            Console.WriteLine("Getting data from Sathyaish.net");
            var barray = task.Result;

            var data = Encoding.ASCII.GetString(barray);
            
            Console.WriteLine(data);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        async static Task<byte[]> GetData(string url)
        {
            var client = new WebClient();
            var data = await client.DownloadDataTaskAsync(url);
            return data;
        }

        static Task<byte[]> GetData2(string url)
        {
            var client = new WebClient();
            return client.DownloadDataTaskAsync(url);
        }

        async static Task<byte[]> GetData3(string url)
        {
            var client = new WebClient();
            var task = client.DownloadDataTaskAsync(url);

            return task.Result;
        }

        async static Task<byte[]> GetData4(string url)
        {
            var client = new WebClient();
            var task = client.DownloadDataTaskAsync(url);
            task.Wait();
            return task.Result;
        }
    }
}
