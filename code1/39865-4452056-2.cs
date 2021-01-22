    // string source, destination; - folder paths 
    int pathLen = source.Length + 1;
    foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
    {
        string subPath = dirPath.Substring(pathLen);
        string newpath = Path.Combine(destination, subPath);
        Directory.CreateDirectory(newpath );
    }
    
    foreach (string filePath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
    {
        string subPath = filePath.Substring(pathLen);
        string newpath = Path.Combine(destination, subPath);
        File.Copy(filePath, newpath);
    }
