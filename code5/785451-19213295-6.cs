    [HttpPost]
    public JsonResult POST()
    {
        HttpPostedFile file = null; ;
        string encodedString = //get the file contents, and get the base64 encoded string        
        ModelName obj= new ModelName();
        obj.characters = encodedString;
        return   Json(obj, "text/html");
    
    }
    
