    public static byte[] Compress(byte[,,] uncompressed)
    {
        using (MemoryStream ms = new MemoryStream())
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Compress))
        {   // Write dimensions of the array to the stream
            for (int dim = 0; dim < 3; dim++){
                byte[] dimlen = BitConverter.GetBytes(
                                             uncompressed.GetLongLength(dim));
                gzs.Write(dimlen, 0, dimlen.Length);
            }
            int bufferlen = 4096, bufptr = 0;
            byte[] buffer = new byte[bufferlen];
            for (long x = 0; x < uncompressed.GetLongLength(0); x++)
            {
                for (long y = 0; y < uncompressed.GetLongLength(1); y++)
                {
                    for (long z = 0; z < uncompressed.GetLongLength(2); z++)
                    {   // Write to buffer; if it is full, write buffer to stream
                        buffer[bufptr] = uncompressed[x, y, z];
                        if(bufptr == bufferlen - 1)
                            gzs.Write(buffer, 0, bufferlen);
                        bufptr = (bufptr + 1) % bufferlen;
                    }
                }
            }
            // Write the rest of the buffer to the compression stream
            if (bufptr != 0) gzs.Write(buffer, 0, bufptr);
            gzs.Close();
            return ms.ToArray();
        }
    }
