    protected override void OnResize(EventArgs e)
    {
         this.Invalidate();
         base.OnResize(e);
    }
    
    protected override void OnPaint(PaintEventArgs e) {
    {
         base.OnPaint(e);
         repaintingMyStuffHere(e.Graphics);
    }
