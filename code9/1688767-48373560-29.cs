        private static Random rnd = new Random();
        // Add whatever 'matrix' characters you want to this array. If you prefer to have one 
        // character chosen more often than the others, you can write code to favor a specific
        // index, or just add more instances of that character to the array below:
        private static char[] matrixChars = new[] { '░', '▒', '▓', '█' };
        static string GetMatrixLine(int density)
        {            
            var line = new StringBuilder();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                // Choose a random number from 0-99 and see if it's greater than density
                line.Append(rnd.Next(100) > density 
                    ? ' '  // If it is, add a space to reduce line density
                    : matrixChars[rnd.Next(matrixChars.Length)]); // Pick a random character
            }
            return line.ToString();
        }
