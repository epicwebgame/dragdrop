using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

// Read the compiler generated state machine code
// to find out if the work inside of the awaited task
// gets done on the same synchronization context as the calling
// thread, in this case the UI thread, and therefore, to see if
// the work inside an awaited task gets done on the UI thread
// regardless of what the implementer of the Task returning method
// we are awaiting wrote inside the method as its implementation.
// TEST ALL OF THIS IF I DON'T USE ConfigureAwait(false)

// I have gotten an answer to my question by debugging this program.
// Please see my stack overflow question here for the findings: http://stackoverflow.com/questions/37666430/does-the-switching-of-a-synchronization-context-mean-that-the-work-will-run-on-t
// Permalink: http://stackoverflow.com/q/37666430/303685
namespace DoesWorkInsideAwaitedMethodRunOnCallingSyncContext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var s = await GetStringAsync();
            button1.Text = s;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var s = await Task.Run(() => 
            {
                Debugger.Break();
                
                return "string 2";
            });

            button2.Text = s;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var s = await UserQueuedWorkItemWithCallback();

            button3.Text = s;
        }

#pragma warning disable 1998
        private async Task<string> GetStringAsync()
        {
            Debugger.Break();
            
            return "string 1";
        }

        private async Task<string> UserQueuedWorkItemWithCallback()
        {
            try
            {
                // I am, on purpose, not going to acquire
                // the sync context and pass it to the func
                // and call Control.Invoke / this.Invoke to
                // run the func within the sync context of the
                // UI thread.

                // Let me see if the state machine that await produces does
                // anything of the sort.
                Func<string> func = () =>
                {
                    Debugger.Break();
                    
                    return "string 3";
                };

                var asyncResult = func.BeginInvoke(null, null);

                // block till done
                return func.EndInvoke(asyncResult);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.ToString());
                Debugger.Break();
                return "string " + ex.Message;
            }
        }
#pragma warning restore 1998
    }
}