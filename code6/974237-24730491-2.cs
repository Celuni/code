    public class Username
    {
        [Index(IsUnique = true)]
        public int Id {get;set;}
        [Index(IsUnique = true)]
        public string Name {get;set;}
    }
