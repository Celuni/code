    public class YourKey
    {
        public int Item1 { get; private set; }
        public int Item2 { get; private set; }
        public YourKey(int item1, int item2)
        {
           this.Item1 = item1;
           this.Item2 = item2;
        }
        public override bool Equals(object obj)
        {
            YourKey temp = obj as YourKey;
            if (temp !=null)
            {
                return temp.Item1 == this.Item1 && temp.Item2 == this.Item2;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 37;
            hash = hash * 31 + Item1;
            hash = hash * 31 + Item2;
            return hash;
        }
    }
