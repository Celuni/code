    [ComImport, Guid("9068270b-0939-11d1-8be1-00c04fd8d503"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface IAdsLargeInteger
    {
        long HighPart
        {
            [SuppressUnmanagedCodeSecurity] get; [SuppressUnmanagedCodeSecurity] set;
        }
    
        long LowPart
        {
            [SuppressUnmanagedCodeSecurity] get; [SuppressUnmanagedCodeSecurity] set;
        }
    }
