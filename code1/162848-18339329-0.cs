    [DataContract]
    [KnownType(typeof(List<String>))]
    public class Foo
    {
        [DataMember]
        public String FooName { get; set; }
        [DataMember]
        public IDictionary<String, Object> Inputs { get; set; }
        private Object UsedForKnownTypeSerializationObject{ get; set; }
        
    }
