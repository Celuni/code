    private List<TextBox> GetCustomClasses()
    {
        List<TextBox> tb = new List<TextBox>();
        List<String> indexes = new List<string>();
        //  N.B. A more conservative implementation might want to go for an unsigned 
        //  64-bit thing here. Just in case you run into a really big GroupBox.
        for (String i = "0"; Int32.Parse(i) < 0x7fffffff; i = (Int32.Parse(i) + 1).ToString())
        {
            indexes = new List<string>(indexes);
            indexes.Add(i);
        }
        var arrayOfIndexes = indexes.ToArray();
        var reordered = new TextBox[gb_customClasses.Controls.Count];
        foreach (Control con in gb_customClasses.Controls)
            if (con.Name.Contains("tb_class"))
                reordered[arrayOfIndexes.ToList().IndexOf(con.Name.Replace("tb_class", ""))] = con as TextBox;
        return reordered.ToList();
    }
