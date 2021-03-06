    public class MyObject
    {
        public string StringProperty {get; set;}
        public int IntProperty {get; set;}
        public object this[string PropertyName]
            {
                get
                {
                    return GetType().GetProperty(PropertyName).GetGetMethod().Invoke(this, null);
                }
                set
                {
                    GetType().GetProperty(PropertyName).GetSetMethod().Invoke(this, new object[] {value});
                }
            }
    }
