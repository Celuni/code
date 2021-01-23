    [JsonConverter(typeof(JsonSubtypes), "Sound")]
    [JsonSubtypes.KnownSubType(typeof(Dog), "Bark")]
    [JsonSubtypes.KnownSubType(typeof(Cat), "Meow")]
    public class Animal
    {
        public virtual string Sound { get; }
        public string Color { get; set; }
    }
    
    public class Dog : Animal
    {
        public override string Sound { get; } = "Bark";
        public string Breed { get; set; }
    }
    
    public class Cat : Animal
    {
        public override string Sound { get; } = "Meow";
        public bool Declawed { get; set; }
    }
