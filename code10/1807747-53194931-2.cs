    public class Node
    {
        public string Name { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        private static class Connector
        {
            public const char Single = '╚';
            public const char Double = '╠';
        }
        private static class Position
        {
            public const string Empty = "";
            public const string Left = "Left : ";
            public const string Right = "Right: ";
        }
        /// <summary>
        /// Creates a Node based on a valid input string: "(Name(Left)(Right))", 
        /// where 'Left' and 'Right' are empty or valid strings like above.
        /// </summary>
        /// <param name="input">Input string to parse</param>
        /// <returns>Root node of the tree</returns>
        public static Node Parse(string input)
        {
            input = input?.Trim();
            // Some light validation
            if (string.IsNullOrEmpty(input) || input == "()") return null;
            if (input.Length < 7)
            {
                throw new ArgumentException(
                    $"input '{input}' is not long enough to represent a valid" +
                    "node. The minimum string length is 7 characters: (A()())");
            }
            if (!input.StartsWith("(") || !input.EndsWith(")"))
            {
                throw new FormatException(
                    $"input '{input}' must be surrounded by parenthesis");
            }
            // Remove outer parenthesis so input is now: "Name(Left)(Right)"
            input = input.Substring(1, input.Length - 2);
            // Find the name and start of left node
            var leftNodeStart = input.IndexOf('(', 1);
            var root = new Node {Name = input.Substring(0, leftNodeStart)};
            if (string.IsNullOrEmpty(root.Name)) root.Name = "{empty}";
            // Remove name so input is now just: "(Left)(Right)"
            input = input.Substring(leftNodeStart);
            // Find the end of the left node by counting opening and closing parenthesis
            // When the opening count is equal to the closing count, we have our Left set
            var openParenthesisCount = 0;
            var closeParenthesisCount = 0;
            var leftNodeLength = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '(') openParenthesisCount++;
                else if (input[i] == ')') closeParenthesisCount++;
                if (openParenthesisCount == closeParenthesisCount)
                {
                    leftNodeLength = i + 1;
                    break;
                }
            }
            root.Left = Node.Parse(input.Substring(0, leftNodeLength));
            root.Right = Node.Parse(input.Substring(leftNodeLength));
            return root;
        }
        public void Print()
        {
            PrintTree();
        }        
        private void PrintTree(string indent = "", string position = Position.Empty,
            bool extendParentConnector = false, char connector = Connector.Single)
        {
            // Update indent with 
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (extendParentConnector && indent.Length > 8 )
            {
                var replaceIndex = indent.Length - 9;
                indent = indent.Remove(replaceIndex, 1).Insert(replaceIndex, "║");
            }
            Console.Write(indent + connector + '═');            
            Console.ForegroundColor = position == Position.Left
                ? ConsoleColor.DarkGreen
                : position == Position.Right ? ConsoleColor.DarkYellow : ConsoleColor.Gray;
            
            Console.Write(position);
            Console.ResetColor();
            Console.WriteLine(Name);
            var nextIndent = indent + new string(' ', position.Length + 2);
            var extendParent = connector == Connector.Double;
            Left?.PrintTree(nextIndent, Position.Left, extendParent, 
                Right == null ? Connector.Single : Connector.Double);
            Right?.PrintTree(nextIndent, Position.Right, extendParent);
        }
    }   
