    using System.Linq;
    using System.Text.RegularExpressions;
    public static string Decode(string morseCode) {
      string[] words = Regex.Matches(source, @"(?<=^|\s).+?(?=$|\s)")
        .Cast<Match>()
        .Select(match.Value.All(c => char.IsWhiteSpace(c)) 
           ? match.Value 
           : match.Value.Trim())
        .ToArray();
      //Relevant code here
    }
