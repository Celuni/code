    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsForms_22296644
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
            IEnumerable<object> GetNavigator(string[] urls, Action next)
            {
                WebBrowserDocumentCompletedEventHandler handler = 
                    delegate { next(); }
    
                this.webBrowser.DocumentCompleted += handler;
                try
                {
                    foreach (var url in urls)
                    {
                        this.webBrowser.Navigate(url);
                        yield return Type.Missing;
                        MessageBox.Show(this.webBrowser.Document.Body.OuterHtml);
                    }
                }
                finally
                {
                    this.webBrowser.DocumentCompleted -= handler;
                }
            }
    
            void StartNavigation(string[] urls)
            {
                IEnumerator<object> enumerator = null;
                Action next = () => enumerator.MoveNext();
                enumerator = GetNavigator(urls, next).GetEnumerator();
                next();
            }
    
            private void Form_Load(object sender, EventArgs e)
            {
                StartNavigation(new[] { 
                    "http://example.com",
                    "http://example.net",
                    "http://example.org" });
            }
        }
    }
