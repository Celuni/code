    /// <summary>
    /// This is a nice variant of the KeyNotFoundException. The original version 
    /// is very mean, because it refuses to tell us which key was responsible 
    /// for raising the exception.
    /// </summary>
    public class NiceKeyNotFoundException<TKey> : KeyNotFoundException
    {
        public TKey Key { get; private set; }
        public NiceKeyNotFoundException(TKey key, string message)
            : base(message, null)
        {
            this.Key = key;
        }
        public NiceKeyNotFoundException(TKey key, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Key = key;
        }
    }
    /// <summary>
    /// This is a very nice dictionary, because it throws a NiceKeyNotFoundException that
    /// tells us the key that was not found. Thank you, nice dictionary!
    /// </summary>
    public class NiceDictionary<TKey, TVal> : Dictionary<TKey, TVal>
    {
        public new TVal this[TKey key]
        {
            get
            {
                try
                {
                    return base[key];
                }
                catch (KeyNotFoundException knfe)
                {
                    string msg = "Key '" + key.ToString() + "' could not be found.";
                    throw new NiceKeyNotFoundException<TKey>(key, msg, knfe.InnerException);
                }
            }
            set
            {
                try
                {
                    base[key] = value;
                }
                catch (KeyNotFoundException knfe)
                {
                    string msg = "Key '" + key.ToString() + "' could not be found.";
                    throw new NiceKeyNotFoundException<TKey>(key, msg, knfe.InnerException);
                }
            }
        }
    }
