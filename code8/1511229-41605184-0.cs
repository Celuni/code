    public static void Main(string[] args) 
    {
        DoSomething (new string[] { "I", "Like", "π" });
    }
    
    public static void DoSomething(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine (array [i]);
        }
    }
