    [HttpPost]
    public ActionResult AddProdct(Product DataProduct)
    {
        int UserId = WebSecurity.GetUserId(User.Identity.Name);
    
        // var r = new List<Product>();
        var Data =  db.Product.Add(DataProduct);
        Data.ID_User = UserId;
        Data.ID_Category = DataProduct.ID_Category;
        Data.Name_Product = DataProduct.Name_Product;
         // Count varible 
        int  count = 0 ; 
      
        foreach(string file in Request.Files)
        {
            
    
            HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
            if (hpf.ContentLength == 0)
                continue;
            string saveFileName = Path.GetFileName(hpf.FileName);
            string location = Path.Combine(Server.MapPath("~/Images/Product"+ @"\" + saveFileName.Replace('+', '_')));
            Request.Files[file].SaveAs(location);
           // Data.imageUrl1 = saveFileName;
           if ( i  >= 3) 
               i = 0 ;
          // Count + 1 each time
             i++ ; 
            if (i == 1 ) 
             { 
                 Data.imageUrl1 = saveFileName ; 
             }
            else if (i == 2) 
            {
                 Data.imageUrl2 = saveFileName ; 
            } 
           else if (i == 3 ) 
            {
                Data.imageUrl3 = saveFileName ; 
            } 
    
    
        }
    
        db.SaveChanges();
    }
