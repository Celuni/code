    void PrintBitmap(Bitmap bm)
    {
        PrintDocument doc = new PrintDocument();
        doc.PrintPage += (s, e) => {
            ev.Graphics.DrawImage(Point.Empty); // adjust this to put the image elsewhere
            ev.HasMorePages = false;
        };
        doc.Print();
    }
