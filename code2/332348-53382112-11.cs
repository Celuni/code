    //byte[] byteArray = File.ReadAllBytes("Test.docx"); // you might be able to assign your bytes here, instead of from a file?
    byte[] byteArray = GetByteArrayFromDatabase(fileId); // function you have for getting the document from the database
    using (MemoryStream mem = new MemoryStream())
    {
        mem.Write(byteArray, 0, (int)byteArray.Length);
        using (WordprocessingDocument wordDoc =
                WordprocessingDocument.Open(mem, true))
        {
            // do your updates -- see string or XML edits, above
            // Once done, don't forget to save the changes....
            wordDoc.MainDocumentPart.Document.Save();
        }
        // But you will still need to save it to the file system here....
        // You would update "documentPath" to a new name first...
        string documentPath = @"C:\temp\newDoc.docx";
        using (FileStream fileStream = new FileStream(documentPath,
                System.IO.FileMode.CreateNew))
        {
            mem.WriteTo(fileStream);
        }
    }
    // And then read the bytes back in, to save it to the database
    byteArray = File.ReadAllBytes(documentPath); // new bytes, ready for DB saving
