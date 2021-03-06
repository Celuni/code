    Bitmap bm = (Bitmap)Bitmap.FromFile("d:\\ImgA_VGA.png");
    pictureBox1.Image = bm;
    Dictionary<Color, int> histo = new Dictionary<Color, int>();
    for (int x = 0; x < bm.Size.Width; x++)
        for (int y = 0; y < bm.Size.Height; y++)
        {
            Color c = bm.GetPixel(x, y);   // **1**
            if (histo.ContainsKey(c))  histo[c] = histo[c] + 1;
            else histo.Add(c, 1);
        }
    var result1 = histo.OrderByDescending(a => a.Value);
    int number = 10;
    var mostusedcolor = result1.Select(x => x.Key).Take(number).ToList();
    Double temp;
    Dictionary<Color, Double> dist = new Dictionary<Color, double>();
    Dictionary<Color, Color> mapping = new Dictionary<Color, Color>();
    foreach (var p in result1)
    {
        dist.Clear();
        foreach (Color pp in mostusedcolor)
        {
            temp = Math.Abs(p.Key.R - pp.R) + 
                   Math.Abs(p.Key.R - pp.R) + 
                   Math.Abs(p.Key.R - pp.R);
            dist.Add(pp, temp);
        }
        var min = dist.OrderBy(k => k.Value).FirstOrDefault();
        mapping.Add(p.Key, min.Key);
    }
    Bitmap copy = new Bitmap(bm);
    for (int x = 0; x < copy.Size.Width; x++)
        for (int y = 0; y < copy.Size.Height; y++)
        {
            Color c = copy.GetPixel(x, y);   // **2**
            copy.SetPixel(x, y, mapping[c]);
        }
    pictureBox2.Image = copy;
