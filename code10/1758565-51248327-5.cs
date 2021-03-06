    private static IEnumerable<string> Staff(string file) 
    {
        return File
            .ReadLines(file)
            .SkipWhile(line => line != "Sentence A")  // Skip until Sentence A found 
            .Skip(1)                                  // Skip Sentence A itself
            .TakeWhile(line => line != "Sentence B"); // Take until Sentence B found 
    }
