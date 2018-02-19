using System;
using System.Windows.Forms;

namespace DisableWebBrowserControlContextMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;

            webBrowser1.Navigate("C:\\Sathyaish\\temp\\Nice Journal.pdf");

            webBrowser1.Document.ContextMenuShowing += Document_ContextMenuShowing;
        }

        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            webBrowser1.ContextMenu?.Show(this, Cursor.Position);
            e.ReturnValue = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = e.Url.LocalPath;
        }
    }
}
