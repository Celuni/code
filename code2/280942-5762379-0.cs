    public static int CountDifferences<T>(this IList<T> list1, IList<T> list2)
    {
        if (list1.Count != list2.Count)
            throw new ArgumentException("Lists must have the same number of elements", "list2");
        int count  = list1.Zip(list2, (a, b) => a.Equals(b) ? 0 : 1).Sum();
        return count;
    }
