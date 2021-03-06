    [Serializable]
    public struct HexPoint : IEquatable<HexPoint>
    {
        // Those are not displayed in the inspector, 
        // readonly and accessible by other classes
        public int x { get { return _x; }}
        public int y { get { return _y; }}
        public int z { get { return _z; }}
    
        // Those are displayed in the Inspector
        // but private and therefor not changable by other classes
        [SerializeField] private int _x;
        [SerializeField] private int _y;
        [SerializeField] private int _z;
    }
