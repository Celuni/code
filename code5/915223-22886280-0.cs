    // code on the click of the button/link
 
    FileInfo file = new FileInfo(tempFilePathOnServer);
    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "\"");
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = "text/xml";
    Response.Flush();
    Response.TransmitFile(file.FullName);
    Response.End();
