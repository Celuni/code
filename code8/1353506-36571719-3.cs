    string file = @"D:\MyDirectory\MyFile.po";
    string[] allLines = System.IO.File.ReadAllLines(file);
    for(int i = 0; i < allLines.GetLength(0); i++)
    {
        allLines[i] = allLines[i].Replace("'",@"&#39");
    }
    System.IO.File.WriteAllLines(file,allLines);
