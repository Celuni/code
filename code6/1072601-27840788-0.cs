    public static BitmapImage ByteArraytoBitmap(Byte[] byteArray)
    {
        MemoryStream stream = new MemoryStream(byteArray);
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
        return bitmapImage;
    }
