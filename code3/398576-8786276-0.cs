    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleStruct
    {
        [FieldOffset(0)]
        public double value;
            
        [FieldOffset(0)]
        public byte byte0;
            
        [FieldOffset(1)]
        public byte byte1;
        [FieldOffset(2)]
        public byte byte2;
            
        [FieldOffset(3)]
        public byte byte3;
        [FieldOffset(4)]
        public byte byte4;
        [FieldOffset(5)]
        public byte byte5;
        [FieldOffset(6)]
        public byte byte6;
        [FieldOffset(7)]
        public byte byte7;
    }
