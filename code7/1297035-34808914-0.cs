    public class LatLon
    {
        public double lat {get;set;}
        public double lon {get;set;}
    }
    class ProximityFilter
    {
        private LatLon m_last = null;
            
        internal bool DifferentFromPrevious(LatLon arg)
        {
            if (m_last == null)
            {
                m_last = arg;
                return true;
            }
            var ret = Math.Abs(arg.lat - m_last.lat) > 0.001 || Math.Abs(arg.lon - m_last.lon) > 0.001;
            m_last = arg;
            return ret;
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            var p1 = new LatLon { lat = 49.9429989, lon = 3.9542134};
            var p2 = new LatLon { lat = 49.9529989, lon = 3.9642134 };
            var p3 = new LatLon  { lat = 49.9429989, lon = 3.9542133 };
            var p4 = new LatLon { lat = 49.9429989, lon = 3.9542136 };
            var list = new List<LatLon> {p1, p2, p3, p4};
            var filter = new ProximityFilter();
            var cleaned = list.Where(filter.DifferentFromPrevious);
            // ...
        }
    }
