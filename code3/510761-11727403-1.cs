    [MyAttribute(MyClass.MyClassName)]
    public MyClass
    {
        private const string MyClassName = "Test123";
        
        public string Name 
        {
           get { return MyClass.MyClassName; }
        }
    }
