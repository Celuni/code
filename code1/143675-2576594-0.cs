    public ActionResult Index(int? id){ 
        if( id.HasValue ){
            File file = fileRepository.GetFile(id);
            if (file == null) return Content("Not Found");
                return Content(file.FileID.ToString());
        } else {
            return Content("Index ");
        }
    }
