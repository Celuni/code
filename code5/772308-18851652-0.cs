    public static class ListExtensions
    {
        public static IEnumerable<T> DoCoolStuff<T>(this List<T> collection) where T : MyClass
        {
            // Do cool stuff
        }
    }
