    private static void Main(string[] args)
    {
        byte[] byteArr1 = new byte[4096];
        GCHandle obj1Handle = GCHandle.Alloc(byteArr1 , GCHandleType.Pinned);
        object byteArr2 = new byte[4096];
        GCHandle obj2Handle = GCHandle.Alloc(byteArr2, GCHandleType.Pinned);
        object byteArr3 = new byte[4096];
        object byteArr4 = new byte[4096];
        object byteArr5 = new byte[4096];
        GCHandle obj4Handle = GCHandle.Alloc(byteArr5, GCHandleType.Pinned);
        GC.Collect(2, GCCollectionMode.Forced);
    }
