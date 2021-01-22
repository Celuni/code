    public class MyList<T> : List<T>
    {
        public void AddRange<Tother>(IEnumerable<Tother> col)
            where Tother: T
        {    
            foreach (Tother item in col)
            {
                this.Add(item);
            }
        }
    }
