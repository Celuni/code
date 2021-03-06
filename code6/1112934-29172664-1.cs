	static void Main(string[] args)
    {
        // map expected inputs to their corresponding files
		var inputMap = new Dictionary<string, string>
		{
			{ "day", "Day.txt" },
			{ "date", "Date.txt" },
			{ "close", "SH1_Close.txt" },
			...
		};
        Console.WriteLine("Which array would you like to view?");
        string input = Console.ReadLine(); 
        // Make sure there was input and it's in the map; get it if it is
		string filePath;
		if (string.IsNullOrEmpty(input) || !inputMap.TryGetValue(input.ToLower(), out filePath))
		{
			Console.WriteLine("Sorry, you entered an invalid term, please enter: day, date, close, difference, open or volume.");
			return;
		}
		
        // Make sure the file exists
        if (File.Exists(filePath))
        {
            // read all lines from the file
		    string[] fileLines = File.ReadAllLines(filePath);
            // join them with a space and output to console
		    Console.WriteLine(string.Join(' ', fileLines));
        }
        else
        {
            Console.WriteLine("Sorry, the file doesn't exist.");
        }
        Console.Read();
    }
