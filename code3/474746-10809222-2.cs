    namespace MemAllocLib
    {
        public sealed class ChunkAllocator : IDisposable
        {
            IntPtr m_chunkStart;
            int m_offset;//offset from already allocated memory
            readonly int m_size;
            public ChunkAllocator(int memorySize = 1024)
            {
                if (memorySize < 1)
                    throw new ArgumentOutOfRangeException("memorySize must be positive");
                m_size = memorySize;
                m_chunkStart = Marshal.AllocHGlobal(memorySize);
            }
            ~ChunkAllocator()
            {
                Dispose();
            }
            public IntPtr Allocate<T>() where T : struct
            {
                int reqBytes = Marshal.SizeOf(typeof(T));//not highly performant
                return Allocate<T>(reqBytes);
            }
            public IntPtr Allocate<T>(int reqBytes) where T : struct
            {
                if (m_chunkStart == IntPtr.Zero)
                    throw new ObjectDisposedException("ChunkAllocator");
                if (m_offset + reqBytes > m_size)
                    throw new OutOfMemoryException("Too many bytes allocated: " + reqBytes + " needed, but only " + (m_size - m_offset) + " bytes available");
                T created = default(T);
                Marshal.StructureToPtr(created, m_chunkStart + m_offset, false);
                m_offset += reqBytes;
                return m_chunkStart + (m_offset - reqBytes);
            }
            public void Dispose()
            {
                if (m_chunkStart != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(m_chunkStart);
                    m_offset = 0;
                    m_chunkStart = IntPtr.Zero;
                }
            }
            public void ReleaseAllMemory()
            {
                m_offset = 0;
            }
            public int AllocatedMemory
            {
                get { return m_offset; }
            }
            public int AvailableMemory
            {
                get { return m_size - m_offset; }
            }
            public int TotalMemory
            {
                get { return m_size; }
            }
            public static T ConvertPointerToStruct<T>(IntPtr ptr) where T : struct
            {
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            public static void StoreStructure<T>(IntPtr ptr, T data) where T : struct
            {
                Marshal.StructureToPtr(data, ptr, false);
            }
        }
    }
