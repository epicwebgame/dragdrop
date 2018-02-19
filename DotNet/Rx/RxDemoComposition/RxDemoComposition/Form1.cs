using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RxDemoComposition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var observable = new List<int> { 1, 2, 3 }.ToObservable();

            using (observable.Subscribe(v =>
            {
                Text = System.Threading.SynchronizationContext.Current?.GetType().Name;
                Debugger.Break();

                Thread.Sleep(2000);
                Text = v.ToString();
            }))
            {
            }
        }
    }

    class NumberObserver : IObserver<int>
    {
        public void OnCompleted()
        {
            Debug.Print("Completed");
        }

        public void OnError(Exception error)
        {
            Debug.Print("Error");
        }

        public void OnNext(int value)
        {
            // 3. Get your value or whatever from the callback you
            // gave to the Subscribe method, i.e. from the IObserver<T>
            // that you gave to the Subscribe method.

            Debug.Print(value.ToString());
        }
    }
}
