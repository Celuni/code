    using (var stream = new FileStream(drvFile, FileMode.Open, FileAccess.ReadWrite))  
    { 
        Byte[] bytes = System.Text.ASCIIEncoding.GetBytes(txtTotalSeasons.Text); 
    }
    {        
        stream.Position = 4; 
        stream.WriteByte(0xCD); 
    }
