    public partial class RedrawInWndProcForm : Form
    {
        public RedrawInWndProcForm()
        {
            InitializeComponent();
            p = new Pen(Color.Red, 2.0f);
            this.SizeChanged += (s, e) => { this.Invalidate(); };
        }
        Graphics g; 
        Pen p;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0xf:  // WM_PAINT
                    {
                        g = Graphics.FromHwnd(this.Handle);
                        Rectangle r = GetWndRect(this.Handle);
                        g.DrawRectangle(p, r);
                        Trace.WriteLine("WM_PAINT: " + r.ToString());
                    }
                    break;
            }
            Trace.WriteLine("handled");
            base.WndProc(ref m);
        }
        
        private Rectangle GetWndRect(IntPtr hwnd)
        {
            return new Rectangle(0, 0, (int)this.ClientSize.Width, (int)this.ClientSize.Height);
        }
    }
