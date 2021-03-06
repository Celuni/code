    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        static class Program
        {
            private const int WM_NCLBUTTONDOWN = 0xA1,
                                    HT_CAPTION = 0x2;
    
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    
            [DllImport("user32.dll")]
            private static extern bool ReleaseCapture();
    
            class MultipleFormsOpen : ApplicationContext
            {
                public MultipleFormsOpen()
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Random r = new Random();
    
                        Form testform = new Form()
                        {
                            BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)),
                            FormBorderStyle = FormBorderStyle.None
                        };
    
                        testform.MouseDown += (s, me) =>
                        {
                            if (me.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(testform.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
                        };
    
                        testform.FormClosed += (s, fe) =>
                        {
                            if (Application.OpenForms.Count == 0)
                            {
                                ExitThread();
                            }
                        };
    
                        testform.Controls.Add(new FlatClose());
    
                        testform.Show();
                    }
                }
            }
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MultipleFormsOpen());
            }
        }
    }
