        class Program
        {
            static void Main(string[] args)
            {
                var url = @"http://www.dsebd.org/displayCompany.php?name=NBL";
    
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                {
    
                    // Or you can get the file content without saving it:
                    string htmlCode = client.DownloadString(url);
                    htmlCode = htmlCode.Substring(
                        htmlCode.IndexOf("Last Trade:")
                        );
                    htmlCode = htmlCode.Substring("2\">", "</font></td>").Trim();
                    Console.WriteLine(htmlCode);
                    //...
                }
                Console.ReadLine();
            }
        }
        // http://stackoverflow.com/a/17253735/3147740
        public static class StringExtensions
        {
            /// <summary>
            /// takes a substring between two anchor strings (or the end of the string if that anchor is null)
            /// </summary>
            /// <param name="this">a string</param>
            /// <param name="from">an optional string to search after</param>
            /// <param name="until">an optional string to search before</param>
            /// <param name="comparison">an optional comparison for the search</param>
            /// <returns>a substring based on the search</returns>
            public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
            {
                var fromLength = (from ?? string.Empty).Length;
                var startIndex = !string.IsNullOrEmpty(from)
                    ? @this.IndexOf(from, comparison) + fromLength
                    : 0;
    
                if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }
    
                var endIndex = !string.IsNullOrEmpty(until)
                ? @this.IndexOf(until, startIndex, comparison)
                : @this.Length;
    
                if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }
    
                var subString = @this.Substring(startIndex, endIndex - startIndex);
                return subString;
            }
        }
