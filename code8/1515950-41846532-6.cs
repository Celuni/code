    return new FileStreamResultEx(response, res.ContentLength, mimeType, downloadName);
    public class FileStreamResultEx : ActionResult{
         public FileStreamResultEx(
            Stream stream, 
            long contentLength,         
            string mimeType,
            string fileName){
            this.stream = stream;
            this.mimeType = mimeType;
            this.fileName = fileName;
            this.contentLength = contentLength;
         }
         public override void ExecuteResult(
             ControllerContext context)
         {
             var response = context.HttpContext.Response; 
             response.BufferOutput = false;
             response.Headers.Add("Content-Type", mimeType);
             response.Headers.Add("Content-Length", contentLength.ToString());
             response.Headers.Add("Content-Disposition","attachment; filename=" + fileName);
             using(stream) { 
                 stream.CopyTo(response.OutputStream);
             }
         }
    }
