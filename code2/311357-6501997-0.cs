    public static void Main()
    {
        var image = Image.FromFile(@"c:\logo.png");
        var newImage = ScaleImage(image, 300, 400);
        newImage.Save(@"c:\test.png", ImageFormat.Png);
    }
    public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
    {
        var ratioX = (double)maxWidth / image.Width;
        var ratioY = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratioX, ratioY);
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);
        Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
        return newImage;
    }
