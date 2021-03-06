    using (Image src = Image.FromFile("main.gif"))
    using (Bitmap dst = new Bitmap(100, 129))
    using (Graphics g = Graphics.FromImage(dst))
    {
       g.SmoothingMode = SmoothingMode.AntiAlias;
       g.InterpolationMode = InterpolationMode.HighQualityBicubic;
       g.DrawImage(src, 0, 0, dst.Width, dst.Height);
       dst.Save("scale.png", ImageFormat.Png);
    }
