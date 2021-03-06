    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        var center = new Point(100, 100);
        var innerR = 30;
        var thickness = 20;
        var startAngle = 270;
        var arcLength = 120;
        var outerR = innerR + thickness;
        var outerRect = new Rectangle
                        (center.X - outerR, center.Y - outerR, 2 * outerR, 2 * outerR);
        var innerRect = new Rectangle
                        (center.X - innerR, center.Y - innerR, 2 * innerR, 2 * innerR);
        using (var p = new GraphicsPath())
        {
            p.AddPie(outerRect, startAngle, arcLength);
            p.AddPie(innerRect, startAngle, arcLength);
            e.Graphics.FillPath(Brushes.Green, p);
        }
    }
