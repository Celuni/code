        var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        Console.WriteLine("Write something : ");
        var input = Console.ReadLine().ToLower();
        int total = 0;
        for (int temp = 1; temp <= input.Length; temp++)
        {
            if (vowels.Contains(input[temp - 1]))
            {
                total += temp * (char.ToUpper(input[temp -1]) - 64);
            }
         }
         Console.WriteLine("The length is " + total);
