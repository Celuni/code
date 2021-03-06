    AllFlags = (EnumFlagType)Enum.GetValues(typeof(EnumFlagType))
                                 .Cast<int>().Aggregate((acc, next) => acc | next);
----------
    [Flags]
    enum TestEnum { one = 1, two = 2, three = 4, four = 8 };
    
    void Main()
    {
    
    	var AllFlags = (TestEnum)Enum.GetValues(typeof(TestEnum)).Cast<int>().Sum();
    	
    	Console.WriteLine(AllFlags); // Prints "one, two, three, four"
        Console.WriteLine(AllFlags & ~two); // Prints "one, three, four"
    }
