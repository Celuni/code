    // Console Application Example #2 ;)
    static void Main()
    {
        // An array with numbers
        var array = new int[]{1, 2, 3, 4, 5, 8, 9, 11, 45, 99};
        PrintFiltered(array, IsPair); //<---
    }
    static bool IsPair(int x)
    {
        // True for pair numbers
        return x % 2 == 0;
    }
    static void PrintFiltered(int[] array, Func<int, bool> filter)
    {
        if (array == null) throw new ArgumentNullException("array");
        if (filter== null) throw new ArgumentNullException("filter");
        foreach (var item in array)
        {
            if (filter(item))
            {
                Console.WriteLine(item);
            }
        }
    }
