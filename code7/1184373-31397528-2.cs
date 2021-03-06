        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' '); // getting input as string            
            List<int> nums = new List<int>(); // declaring int array with same length as input
            for (int i = 0; i < input.Length; i++) // starting a for loop to convert input string to int in nums[]
            {                
                int intValue;
                if (Int32.TryParse(input[i].Trim(), out intValue))
                {
                    nums.Add(intValue);
                }
            }
            int max = nums.Max();
            int min = nums.Min();
            Console.WriteLine("Largest: " + max);
            Console.WriteLine("Smallest: " + min);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
