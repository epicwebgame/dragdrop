using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace IsEveryWindowCreatedOnASeparateThread
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Debug.Print(string.Format($"Main thread {Thread.CurrentThread.ManagedThreadId.ToString()}"));

            Application.Run(new Form1());
        }
    }
}
