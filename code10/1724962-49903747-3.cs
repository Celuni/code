    public class Complex : Cartesian
    {
        public Cartesian Base { get {return base;} }
        public int I { get; set; }
    
        // not needed for this example
        //public Complex(int i) { Init(i); }
        public Complex Init(int i)
        {
            I = i;
            return this;
        }
    }
