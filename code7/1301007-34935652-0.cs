    using System.Runtime.InteropServices;
    ...
        [ComImport, Guid("45D64A29-A63E-4CB6-B498-5781D298CB4F")] 
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface ICoreWindowInterop {
            IntPtr WindowHandle { get; }
            bool MessageHandled { set; }
        }
