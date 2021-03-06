    int[] original = new int[] { 1, 2, 3, 4, 5, 6 };
    int[] otherReference = original; // currently points to the same object
    
    Array.Resize(ref original, 3);
    
    Console.WriteLine("---- OTHER REFERENCE-----");
    
    for (int i = 0; i < otherReference.Length; i++)
    {
        Console.WriteLine(i);
    }
    
    Console.WriteLine("---- ORIGINAL -----");
    
    for (int i = 0; i < original.Length; i++)
    {
        Console.WriteLine(i);
    }
