    private void Test()
    {            
        System.IO.MemoryStream data = new System.IO.MemoryStream();
        System.IO.Stream str = TestStream();
        str.CopyTo(data);
        // Reset memory stream
        data.Seek(0, SeekOrigin.Begin);
        byte[] buf = new byte[data.Length];
        int bytesRead = data.Read(buf, 0, buf.Length);
        Debug.Assert(bytesRead == data.Length, 
                        String.Format("Expected to read {0} bytes, but read {1}.",
                            data.Length, bytesRead));                     
    }
 
