    public class MyComparer : IComparer<int>
    {
      public int Compare(int x, int y)
      {
        return x > y
                 ? 1
                 : x < y
                     ? -1
                     : 0;
      }
    }
    // ...
    private void DoStuff()
    {
      var dict = new Dictionary<int, int> {{3, 300}, {2, 200}};
      var sortedDict = new SortedDictionary<int, int>(dict, new MyComparer());
    }
