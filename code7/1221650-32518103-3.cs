    var lines = File.ReadAllLines(@"d:\data\test.txt");
    var modifiedLines = lines.Select(line =>
    {
        if (line.StartsWith("Location=\""))
        {
            return string.Format("Location=\"{0}\"", textBox1.Text);
        }
        else
        {
            return line;
        }
    });
    File.WriteAllLines(@"d:\data\test.txt", modifiedLines);
