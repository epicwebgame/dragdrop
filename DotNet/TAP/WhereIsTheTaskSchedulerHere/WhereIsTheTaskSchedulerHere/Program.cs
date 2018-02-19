using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhereIsTheTaskSchedulerHere
{
    class Program
    {
        // I wasn't able to step-through the source of DownloadBits or WebRequest.BeginGetResponse. They are both in System.dll
        // I posted a question about this here: http://stackoverflow.com/questions/37632518/visual-studio-debugger-not-stepping-into-net-framework-source-code
        // Permalink: http://stackoverflow.com/q/37632518/303685
        static void Main(string[] args)
        {
            var task = GetData("http://sathyaish.net");
            var buffer = task.Result;

            var data = Encoding.ASCII.GetString(buffer);

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
    }
}