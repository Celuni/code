    [AttributeUsage(AttributeTargets.Property)]
    public class RelatedPropertyAttribute : Attribute
    {
        public Type RelatedProperty { get; private set; }
        public RelatedPropertyAttribute(Type relatedProperty)
        {
            RelatedProperty = relatedProperty;
        }
    }
    public class PropertyRelation<TOwner, TProperty>
    {
        private readonly Func<TOwner, TProperty> _propGetter;
        public PropertyRelation(Func<TOwner, TProperty> propGetter)
        {
            _propGetter = propGetter;
        }
        public TProperty GetProperty(TOwner owner)
        {
            return _propGetter(owner);
        }
    }
    public class MyClass
    {
        public int EmployeeId { get; set; }
        [RelatedProperty(typeof(EmployeeNumberRelation))]
        public int EmployeeNumber { get; set; }
        public class EmployeeNumberRelation : PropertyRelation<MyClass, int>
        {
            public EmployeeNumberRelation()
                : base(@class => @class.EmployeeNumber)
            {
            }
        }
    }
