    public class r_type { 
    
        // make it private not to create more than you want
        private r_type(double value) {
            this.Value = value;
        }
    
        public double Value { get; private set;}
        public static implicit operator double(r_type r)
        {
            return r.Value;
        }
    
        // your enum values below
        public static readonly r_type A1 = new r_type(0.1);
        public static readonly r_type A2 = new r_type(0.2);
        public static readonly r_type A4 = new r_type(0.2);
        public static readonly r_type A8 = new r_type(0.8);
    }
