    Files = Request.Files; // Load File collection into HttpFileCollection variable.
    arr1 = Files.AllKeys;  // This will get names of all files into a string array.
    for (loop1 = 0; loop1 < arr1.Length; loop1++) 
    {
        Response.Write("File: " + Server.HtmlEncode(arr1[loop1]) + "<br />");
        Response.Write("  size = " + Files[loop1].ContentLength + "<br />");
        Response.Write("  content type = " + Files[loop1].ContentType + "<br />");
    }
