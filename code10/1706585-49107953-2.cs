    internal class TestObject<T> where T: XObject 
    {
        public string ID;
        public T obj;
        //....
    }    
    internal class TestDocument : TestObject<XDocument>
    {
    } 
