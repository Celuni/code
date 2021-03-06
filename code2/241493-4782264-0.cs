    public static class Enum<T>
    {
        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    
        public List<T> GetValues()
        {
            List<T> values = new List<T>();
            foreach (T value in Enum.GetValues(typeof(T)))
                values.Add(value);
            return values;
        }
    
        public string GetName(object value)
        {
            return Enum.GetName(typeof(T), value);
        }
    }
