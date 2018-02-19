using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InsideSecondExampleAwaitFromReflector
{
    internal class Program
    {
        // Methods
        // I know I should have named this GetDataAsync, but let's ignore that for now
        [AsyncStateMachine(typeof(TheFirstGetDataMethod)), DebuggerStepThrough]
        private static Task<byte[]> GetData(string url)
        {
            TheFirstGetDataMethod stateMachine = new TheFirstGetDataMethod();
            stateMachine.Url = url;
            stateMachine.AsyncTaskOfByteArrayMethodBuilder = AsyncTaskMethodBuilder<byte[]>.Create();
            stateMachine.State = -1;
            stateMachine.AsyncTaskOfByteArrayMethodBuilder.Start<TheFirstGetDataMethod>(ref stateMachine);
            return stateMachine.AsyncTaskOfByteArrayMethodBuilder.Task;
        }

        private static void Main(string[] args)
        {
            Task<byte[]> task = GetData("http://sathyaish.net");
            Console.WriteLine("Getting data from Sathyaish.net");
            byte[] barray = task.Result;
            Console.WriteLine(Encoding.ASCII.GetString(barray));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Nested Types
        [CompilerGenerated]
        private sealed class TheFirstGetDataMethod : IAsyncStateMachine
        {
            // Fields

            // Private fields it created
            private byte[] _byteArray;
            private TaskAwaiter<byte[]> _taskAwaiterOfByteArray;

            // Stuff I had in the original GetDataMethod
            private WebClient _webClient;
            private byte[] _data;

            // Public fields it created
            public int State;
            public AsyncTaskMethodBuilder<byte[]> AsyncTaskOfByteArrayMethodBuilder;
            public string Url;

            // Methods
            // This was private. I changed it to be a public method.
            public void MoveNext()
            {
                byte[] buffer;
                int num = this.State;
                try
                {
                    TaskAwaiter<byte[]> awaiter;
                    if (num != 0)
                    {
                        this._webClient = new WebClient();
                        awaiter = this._webClient.DownloadDataTaskAsync(this.Url).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.State = num = 0;
                            this._taskAwaiterOfByteArray = awaiter;
                            Program.TheFirstGetDataMethod stateMachine = this;
                            this.AsyncTaskOfByteArrayMethodBuilder.AwaitUnsafeOnCompleted<TaskAwaiter<byte[]>, Program.TheFirstGetDataMethod>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this._taskAwaiterOfByteArray;
                        this._taskAwaiterOfByteArray = new TaskAwaiter<byte[]>();
                        this.State = num = -1;
                    }
                    byte[] result = awaiter.GetResult();
                    awaiter = new TaskAwaiter<byte[]>();
                    this._byteArray = result;
                    this._data = this._byteArray;
                    this._byteArray = null;
                    Console.WriteLine("GetData continues running while the WebClient is busy getting data.");
                    buffer = this._data;
                }
                catch (Exception exception)
                {
                    this.State = -2;
                    this.AsyncTaskOfByteArrayMethodBuilder.SetException(exception);
                    return;
                }
                this.State = -2;
                this.AsyncTaskOfByteArrayMethodBuilder.SetResult(buffer);
            }

            // This was private. I changed it to be a public method.
            [DebuggerHidden]
            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }

}