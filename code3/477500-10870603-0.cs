    public string GetBytesFromBinaryString(String binary)
    {
        var list = new List<Byte>();
    
        for (int i = 0; i < binary.Length; i += 8)
        {
            String t = binary.Substring(i, 8);
    
            list.Add(Convert.ToByte(t, 2));
        }
    
        return Encoding.ASCII.GetString(list.ToArray());
    }
