    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }
    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern void DwmExtendFrameIntoClientArea (IntPtr hwnd, 
                                                            ref MARGINS margins);
    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();
