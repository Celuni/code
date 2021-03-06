    struct MinMaxInfo
    {
        public Point ptReserved;
        public Point ptMaxSize;
        public Point ptMaxPosition;
        public Point ptMinTrackSize;
        public Point ptMaxTrackSize;
    }
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m); //do that first: "'Who is the boss' applies. You'd typically want to be the one that has the last say in this case."
        if (m.Msg == 0x0024) //WM_GETMINMAXINFO
        {
            MinMaxInfo minMaxInfo = (MinMaxInfo)m.GetLParam(typeof(MinMaxInfo));
            minMaxInfo.ptMaxSize.X = MaximumSize.Width; //Set size manually
            minMaxInfo.ptMaxSize.Y = MaximumSize.Height;
            minMaxInfo.ptMaxPosition.X = Location.X; //Stay at current position
            minMaxInfo.ptMaxPosition.Y = Location.Y;
            Marshal.StructureToPtr(minMaxInfo, m.LParam, true);
        }
    }
