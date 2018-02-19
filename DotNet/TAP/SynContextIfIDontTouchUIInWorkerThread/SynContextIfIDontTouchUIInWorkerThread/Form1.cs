using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynContextIfIDontTouchUIInWorkerThread
{
    // See http://stackoverflow.com/questions/37635053/why-is-the-synchronization-context-null-even-when-i-try-to-change-ui-from-a-work
    // Permalink: http://stackoverflow.com/q/37635053/303685
    // I got this question by watching Bart de Smet's async deep dive video from Channel 9. See about the middle of the video, about exactly half-way through.
    // Video: https://channel9.msdn.com/Events/TechDays/Techdays-2014-the-Netherlands/Async-programming-deep-dive
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

#pragma warning disable 1998
        private async void button1_Click(object sender, EventArgs e)
        {
            // Nicely prints out the WindowsFormsSynchronizationContext
            // because we *are* indeed on the UI thread
            this.Text = SynchronizationContext.Current.GetType().Name;
            Thread.CurrentThread.Name = "UI Thread";
            Debug.Print(Thread.CurrentThread.Name);

            var t = FooAsync();
            
            // CompletedSynchronously is false, so the other work was indeed run on a worker thread
            button1.Text = (t as IAsyncResult).CompletedSynchronously ? "Sync" : "Async";

            // block the UI thread
            // Code freezes here
            var s = t.Result;

            button1.Text = s;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // This will not block because
            // we are using await instead
            // of the block task.Result property
            // await will do two things:
            // 1. It will run the BarAsync method
            // on the UI synchronization context
            // unless I say await BarAsync().ConfigureAwait(false);
            // 2. It will register the lines of code after the 
            // await as a continuation causing it to run only
            // after the task BarAsync has completed execution
            // so we can be assured that while that worker thread
            // on which BarAsync runs holds the UI sync context, this
            // UI thread is not running as if it had to run at the same time
            // as shown in button1's click handler, it would have needed
            // the same sync context to run on, which would have caused
            // a dead lock.
            var t = BarAsync();

            var s = await t;

            button2.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = GarAsync();
            button3.Text = t.Result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var t = GarAsync();
            t.ContinueWith(task => { button4.Text = task.Result; });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var t = HarAsync();
            button4.Text = t.Result;
        }

        public async Task<string> FooAsync()
        {
            return await Task.Run(() =>
            {
                var ctx = SynchronizationContext.Current;

                if (ctx != null)
                {
                    // The code will not come here
                    Debugger.Break();
                }

                // This result needs to be posted back
                // to the main UI thread, which is blocked
                // waiting for this method to complete because
                // it called task.Result, which is a blocking call
                return "Hello";
            });
        }

        public async Task<string> BarAsync()
        {
            this.Text = SynchronizationContext.Current.GetType().Name;
            return "Hello";
        }

        public async Task<string> GarAsync()
        {
            // This is also the wrong way to do it
            var callSyncContext = SynchronizationContext.Current;

            return await Task.Run(() =>
            {
                string result = null;
                var thisCtx = SynchronizationContext.Current;
                
                if (callSyncContext != null)
                {
                    SynchronizationContext.SetSynchronizationContext(callSyncContext);
                    Debug.Print(SynchronizationContext.Current.GetType().Name);
                    this.Text = SynchronizationContext.Current.GetType().Name;
                    result = "Hello";
                    SynchronizationContext.SetSynchronizationContext(thisCtx);
                }

                return result;
            });
        }

        public Task<string> HarAsync()
        {
            // This will run on the same UI thread
            // and hence is a thread-less task in the sense
            // that no new thread is created or no thread pool 
            // thread is commissioned to run this work.
            // So, this should return on the same thread
            // and hence work without a dead lock.
            this.Text = SynchronizationContext.Current?.GetType().Name;
            var tcs = new TaskCompletionSource<string>();
            tcs.SetResult("Hello");
            return tcs.Task;
        }


        public async Task<string> DarAsync()
        {
            // This is also the wrong way to do it
            var callSyncContext = SynchronizationContext.Current;

            return await Task.Run(() =>
            {
                string result = null;

                if (callSyncContext != null)
                {
                    callSyncContext.Post(o =>
                    {
                        this.Text = SynchronizationContext.Current?.GetType().Name;
                        result = "Hello";
                    }, null);
                }

                // This will return independently of the thread running with the UI sync context
                // that actually sets the result variable
                return result;
            });
        }

        public async Task<string> DarAsync2()
        {
            var callSyncContext = SynchronizationContext.Current;
            var auto = new AutoResetEvent(false);

            return await Task.Run(() =>
            {
                string result = null;

                if (callSyncContext != null)
                {
                    callSyncContext.Post(o =>
                    {
                        this.Text = SynchronizationContext.Current?.GetType().Name;
                        result = "Hello";
                        auto.Set();
                    }, null);
                }

                auto.WaitOne();
                return result;
            });
        }


        public async Task<string> DarAsync3()
        {
            var callSyncContext = SynchronizationContext.Current;
            
            return await Task.Run(() =>
            {
                string result = null;

                if (callSyncContext != null)
                {
                    callSyncContext.Send(o =>
                    {
                        this.Text = SynchronizationContext.Current?.GetType().Name;
                        result = "Hello";
                    }, null);
                }

                return result;
            });
        }


        public async Task<string> MarAsync()
        {
            var callingExecutionContext = ExecutionContext.Capture();
            string result = null;
            var auto = new AutoResetEvent(false);

            if (callingExecutionContext != null)
            {
                ExecutionContext.Run(callingExecutionContext, (s) =>
                {
                    this.Text = SynchronizationContext.Current?.GetType().Name;
                    result = "Hello";
                    auto.Set();
                }, null);
            }

            auto.WaitOne();

            return result;
        }

        public async Task<string> JarAsync()
        {
            var callingExecutionContext = ExecutionContext.Capture();
            string result = null;
            var auto = new AutoResetEvent(false);

            var t = Task.Run(() =>
            {
                if (callingExecutionContext != null)
                {
                    ExecutionContext.Run(callingExecutionContext, (s) =>
                    {
                        Debugger.Break();
                        
                        // return false
                        Debug.Print((callingExecutionContext == ExecutionContext.Capture()).ToString());

                        // Even though we have the WinFormsSyncContext
                        this.Text = SynchronizationContext.Current?.GetType().Name;

                        result = "Hello";
                        auto.Set();
                    }, null);
                }
            });

            auto.WaitOne();
            return result;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var s = await MarAsync();
            Debugger.Break();
            Debug.Print(SynchronizationContext.Current.GetType().Name);
            button6.Text = s;
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var s = await DarAsync2();
            Debugger.Break();
            Debug.Print(SynchronizationContext.Current.GetType().Name);
            button7.Text = s;
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            var s = await JarAsync();
            Debugger.Break();
            Debug.Print(SynchronizationContext.Current.GetType().Name);
            button8.Text = s;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var t = TestContinuationSyncContextAsync();
            var ctx = SynchronizationContext.Current;
            t.ContinueWith(task =>
            {
                ctx.Post((s) => { button9.Text = t.Result; }, null);
            });
        }

        public async Task<string> TestContinuationSyncContextAsync()
        {
            this.Text = SynchronizationContext.Current.GetType().Name;
            return "Hello";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var t = DarAsync3();
            var ctx = SynchronizationContext.Current;
            t.ContinueWith(task =>
            {
                ctx.Post((s) => { button10.Text = t.Result; }, null);
            });
        }


#pragma warning restore 1998
    }
}
