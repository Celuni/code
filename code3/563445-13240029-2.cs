    private static Bitmap ConvertTo24(Bitmap bmpIn)
    {
        Bitmap bmpIn = new Bitmap(@"f:\sara1.bmp");
        Bitmap converted = new Bitmap(bmpIn.Width, bmpIn.Height, PixelFormat.Format24bppRgb);
        using (Graphics g = Graphics.FromImage(converted))
        {
             // Prevent DPI conversion
             g.PageUnit = GraphicsUnit.Pixel;
             // Draw the image
             g.DrawImageUnscaled(bmpIn, 0, 0);
             // g.DrawImage(bmpIn, 0, 0);
        }
        converted.Save(@"F:\sara2.bmp");
    }
