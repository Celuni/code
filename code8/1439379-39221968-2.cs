        public void DrawLine(Point start, Point end, Panel ctrl)
        {
            ctrl.Refresh();
            using ( Graphics g = ctrl.CreateGraphics())
            using ( Pen P = new Pen(Color.Red, 3) )
            {
              P.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
              P.CustomEndCap = 
                new System.Drawing.Drawing2D.AdjustableArrowCap(4, 8, false);
              g.DrawLine(P, start, end);
            }
        }
