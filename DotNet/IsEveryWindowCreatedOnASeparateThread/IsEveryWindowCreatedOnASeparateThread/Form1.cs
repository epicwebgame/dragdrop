using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace IsEveryWindowCreatedOnASeparateThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Debug.Print(string.Format($"Form1 thread {Thread.CurrentThread.ManagedThreadId.ToString()}"));

            InitializeComponent();
        }
    }
}
