    public ActionResult Load(DTParameterModel dtParameters)
      {
        using (Data.Entities context = new Data.Entities())
        {
            var query = context.Customer.AsQueryable();
            query = JqueryDataTableQueryBuilder.BuildQuery(query, dtParameters);
            var result = JqueryDataTableQueryBuilder.GetDTResult(dtParameters, query, a => new
            {
                a.Id,
                a.Name,
                a.LastName
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
     }
