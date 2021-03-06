    public static class Extensions
    {
        public static bool MyExtensionMethod<TKey, TValue>(
            this IDictionary<TKey, List<TValue>> first,
            IDictionary<TKey, List<TValue>> second)
        {
            return true;
        }
    }
    public class A
    {
        public Dictionary<int, List<B>> MyPropertyA { get; set; }
    }
    public class B
    {
        public string MyPropertyB { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new A();
            var a2 = new A();
            var a = a1.MyPropertyA.MyExtensionMethod(a2.MyPropertyA);
        }
    }
