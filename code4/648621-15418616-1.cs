    public static IEnumerable<MyFile> FindUniqueFiles(IEnumerable<MyFile> index1, IEnumerable<MyFile> index2)
    {
        HashSet<string> hash = new HashSet<string>();
        foreach (var file in index1.Concat(index2))
        {
            if (hash.Add(file.Checksum))
            {
                yield return file;
            }
        }
    }
