    static int test;
    static void Main(string[] args)
    {
        resetTest();
        Console.Write(test); // Should be 0
    }
    static void resetTest()
    {
        test = 0;
    }
