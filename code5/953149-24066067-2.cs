    var filesWithoutExtension = System.IO.Directory.GetFiles(@"D:\temp\").Where(filPath => String.IsNullOrEmpty(System.IO.Path.GetExtension(filPath)));
    foreach(string path in filesWithoutExtension)
    {
    	Console.WriteLine(path);
    }
