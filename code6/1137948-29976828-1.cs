    public class State
    {
        public long ID { get; set; }
        ...
        [NonSerialized, JsonIgnore, ScriptIgnore]
        public Country Country { get; set; }
        public long CountryId
        {
            get { return Country.Id; }
            set { Country = new Country(value); }
        }
        ...
    }
