    private static void SplitAfterMBytes(int splitAfterMBytes, string filename)
    {
    	// Variable for max. file size.
    	var maxFileSize = splitAfterMBytes * 1048576;
    	int fileCount = 0;
    	long byteCount = 0;
    	try
    	{
    		var inputFile = new FileInfo(filename);
    		var index = filename.LastIndexOf('.');
    		//get only the name of the file.
    		var fileStart = filename.Substring(0, index);
    		// get the file extension
    		var fileExtension = inputFile.Extension;
    		// generate a new file name.
    		var outputFile = fileStart + '_' + fileCount++ + fileExtension;
    		// file format is like: QS_201101_321.txt.
    		var reader = new StreamReader(filename);
    		var writer = new StreamWriter(outputFile);
    		for (string str; (str = reader.ReadLine()) != null;)
    		{
    			byteCount = byteCount  + System.Text.Encoding.Unicode.GetByteCount(str);
    			if (byteCount >= maxFileSize)
    			{
    				// max. number of bytes reached
    				// write into the old file, without Newline, so that no extra line is written. 
    				writer.Write(str);
    				// 1. close the actual file.
    				writer.Close();
    				// 2. open a new file with number incresed by 1.
    				outputFile = fileStart + '_' + fileCount++ + fileExtension;
    
    				writer = new StreamWriter(outputFile);
    				byteCount = 0; //reset the counter.
    			}
    			else
    			{
    				// Write into the old file.
    				// use a  Linefeed, because Write works without LF.
    				// like Java ;)
    				writer.Write(str); writer.Write(writer.NewLine);
    			}
    		}   // end of for
    		// nicht vergessen, schliessen der beiden Streams.
    		writer.Close();
    		reader.Close();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
