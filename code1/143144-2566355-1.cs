    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        public static void Main()
        {
            string s = "Net     Amount";
            bool isMatch = Regex.IsMatch(s, "Net +Amount");
            Console.WriteLine("isMatch: {0}", isMatch);
        }
    }
