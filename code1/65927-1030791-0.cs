    using System.Text.RegularExpressions;
    ...
    
    foreach(string s in sNames) {
      Match m = Regex.Matches("ID = ([0-9]+)");
      if(m.Success) {
        int id = Convert.ToInt32(m.Groups[1]);
      }
    }
