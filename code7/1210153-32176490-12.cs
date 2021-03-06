        static void Main()
        {
            WorkAt(); // Prints true
            WorkAt("home"); // Prints true because the string is a compile-time constant
            // DeepClone before passing parameter to WorkAt.
            WorkAt(DeepClone("home"));// Prints false for any string.
        }
        static void WorkAt(string location = @"home")
        {
            if (ReferenceEquals(location, @"home")) // Only true when using default parameter
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
        static string DeepClone(string str) // Create a deep copy
        {
             return new string(str.ToCharArray());
        }
