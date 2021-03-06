    public interface ICustomEnum<T>
    {
        ICustomEnum<T> FromT(T value);
        T Value { get; }
    
        // Implement using a private constructor that accepts and sets the Value property, 
        // one shared readonly property for each desired value in the enum,
        // and implicit conversions to and from T.
        // Then see this link to get intellisense support
        // that exactly matches a normal enum:
        // http://stackoverflow.com/questions/102084/hidden-features-of-vb-net/102217#102217
        // Note that the completion list only works for VB.
    }
    /// <completionlist cref="MyStringEnum"/>
    public sealed MyStringEnum : ICustomEnum<string>
    {
        private string _value;
        public string Value { get { return _value; } } 
    
        private MyStringEnum(string value)
        {
            _value = value;
        }
    
        private static MyStringEnum _EnumValueOne = new MyStringEnum("VAL1");
        public static MyStringEnum EnumValueOne { get { return _EnumValueOne;} } 
    
        private static MyStringEnum _EnumValueTwo = new MyStringEnum("VAL2");
        public static MyStringEnum EnumValueTwo { get { return _EnumValueTwo;} } 
    
        public static ICustomEnum<string> FromString(string value) 
            // use reflection or a dictionary here if you have a lot of values
            switch( value )
            {
                case "VAL1":
                    return EnumValueOne;
                case "VAL2":
                    return EnumValueTwo;
                default:
                    return null; //or throw an exception
            }
        }
    
        public ICustomEnum<string> FromT(string value) 
        {
            return FromString(value);
        }
    
        public static implicit operator string(MyStringEnum item)
        {
            return item.Value;
        }
    
        public static implicit operator MyStringEnum(string value)
        {
            return FromString(value);
        }
    }
