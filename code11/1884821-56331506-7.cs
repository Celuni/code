    public static void SaveElement(UIElement element, double dpi, string path)
    {
        var visual = new DrawingVisual();
        var width = element.RenderSize.Width;
        var height = element.RenderSize.Height;
        using (var context = visual.RenderOpen())
        {
            context.DrawRectangle(new VisualBrush(element), null,
                new Rect(0, 0, width, height));
        }
        var bitmap = new RenderTargetBitmap(
            (int)(width * dpi / 96), (int)(height * dpi / 96),
            dpi, dpi, PixelFormats.Default);
        bitmap.Render(visual);
        var encocer = new JpegBitmapEncoder();
        encocer.Frames.Add(BitmapFrame.Create(bitmap));
        using (var stream = File.OpenWrite(path))
        {
            encocer.Save(stream);
        }
    }
