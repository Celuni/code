    public string[] WordList (int stringLength)
    {
        List<string> wordList;
        List<byte> letterCounter;
        string word;
        
        for (int i = 0; i < stringLength; i++)
        {
            letterCounter.Add(0);
        }
    
        while (letterCounter[0] < 25)
        {
            for (int i = 0; i < stringLength; i++)
            {
                char letter = (char)('a' + letterCounter[i]);
                word = new string(word + letter);
            }
    
            wordList.Add(word);
            letterCounter[stringLength]++;
        
            for (int i = stringLength; i > 0; i--)
            {
                if (letterCounter[i] >= 26)
                    if (i > 0)
                        letterCounter [i - 1]++;
            }
        }
    
        return wordList.ToArray();
    }
