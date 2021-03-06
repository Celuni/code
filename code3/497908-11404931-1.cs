    public static class Extensions
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null;
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
        {
            return obj == null || !obj.Any();
        }
    }
