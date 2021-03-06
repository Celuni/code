    public class AgePair<T, Y>
        where T : IComparable<T>
        where Y : IComparable<Y>
    {
        public T A { get; set; }
        public Y B { get; set; }
    }
    public class AgeRecordList<T, Y> : IEnumerable<AgePair<T,Y>>
        where T : IComparable<T>
        where Y : IComparable<Y> 
    {
        private List<AgePair<T, Y>> m_List = new List<AgePair<T, Y>>();
        public void Add(T a, Y b)
        {
            AgePair<T, Y> newPair = new AgePair<T, Y> { A = a, B = b };
            
            var younger = GetYounger(newPair.A);
            foreach (var v in younger)
            {
                if (v.B.CompareTo(newPair.B) >= 0)
                {
                    return; 
                }
            }
                        
            var elder = GetElder(newPair.A);
            List<AgePair<T, Y>> toDelete = new List<AgePair<T, Y>>();
            foreach (var v in elder)
            {
                if (v.B.CompareTo(newPair.B) <= 0)
                {
                    toDelete.Add(v);
                }
            }
            foreach (var v in toDelete)
            {
                m_List.Remove(v);
            }
            m_List.Add(newPair);
            m_List.Sort(CompareA);
        }
        private List<AgePair<T, Y>> GetElder(T t)
        {
            List<AgePair<T, Y>> result = new List<AgePair<T, Y>>();
            foreach (var current in m_List)
            {
                if (t.CompareTo(current.A) <= 0)
                {
                    result.Add(current);
                }
            }
            return result;
        }
        private List<AgePair<T, Y>> GetYounger(T t)
        {
            List<AgePair<T, Y>> result = new List<AgePair<T, Y>>();
            foreach (var current in m_List)
            {
                if (t.CompareTo(current.A) > 0)
                {
                    result.Add(current);
                }
            }
            return result;
        }
        private static int CompareA(AgePair<T,Y> item1, AgePair<T,Y> item2)
        {
            return item1.A.CompareTo(item2.A);
        }
        public IEnumerator<AgePair<T, Y>> GetEnumerator()
        {
            return m_List.GetEnumerator();
        }
    }
