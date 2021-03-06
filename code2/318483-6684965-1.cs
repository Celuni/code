    public static readonly int MaxPath = 260;
    public static string MyPathCanonicalize(string path)
    {
        StringBuilder builder = new StringBuilder(MaxPath);
        if (!PathCanonicalize(builder, path))
            return path;
        return builder.ToString();
    }
