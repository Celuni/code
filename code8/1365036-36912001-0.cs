    public class StarSign : IComparable<StarSign>
    {
        public StarSign(string name, DateTime start, DateTime end)
        {
            if (start >= end) throw new ArgumentException("Start must be < end");
            this.Name = name;
            this.Start = start;
            this.End = end;
        }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CompareTo(StarSign other)
        {
            if (other == null) return 1;
            return Start.CompareTo(other.Start);
        }
        public bool IsStarSign(DateTime dt)
        {
            DateTime normalizedDate = new DateTime(this.Start.Year, dt.Month, dt.Day);
            return normalizedDate >= Start && normalizedDate <= End;
        }
    }
    public class Aquarius : StarSign
    {
        public Aquarius() : base("Aquarius", new DateTime(1, 01, 20), new DateTime(1, 02, 18))
        {
        }
    }
    public class Pisces : StarSign
    {
        public Pisces() : base("Pisces", new DateTime(1, 02, 19), new DateTime(1, 03, 20))
        {
        }
    }
