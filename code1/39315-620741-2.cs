    public static class SomethingFactory
    {
        private static List<Something> listOfSomethings = new List<Something>();
    
        public static Something CreateSomething()
        {
            var something = new Something();
            listOfSomethings.Add(something);
            return something;
        }
    }
