    public static string TrimLongWords(string original, int maxCount)
    {
        if (null == original || original.Length <= maxCount) return original;
        StringBuilder bld = new StringBuilder(original);
        int occurence = 0;
        Char last = '\0';
        List<int> removeAt = new List<int>();
        for (int i = 0; i < original.Length; i++)
        { 
            Char current = original[i];
            if (last == current)
                occurence++;
            else
                occurence = 1;
            if (occurence > maxCount)
                removeAt.Add(i);
            last = current;
        }
        removeAt.Reverse();  // here might be a good place for micro-optimization
        foreach (int i in removeAt)
            bld.Remove(i, 1);
        return bld.ToString();
    }
