    public class DateTimeComparer : Comparer<DateTime>
    {
        private string _Format;
        public DateTimeComparer(string format)
        {
            _Format = format;
        }
        public override int Compare(DateTime x, DateTime y)
        {
            if(x.ToString(_Format) == y.ToString(_Format))
                return 0;
            return x.CompareTo(y);
        }
    }
