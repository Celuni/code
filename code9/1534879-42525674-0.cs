    public class ClassA
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ClassB ClassB { get; set; }
    }
    public class ClassB
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ClassA ClassA { get; set; }
    }
