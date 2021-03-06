    public ActionResult Index()
    {
        var tableNames = TableNames();
        return View("Index", tableNames);
    }
    
    public TableViewModel TableNames()
    {
        String[] tableNamesPath = Directory.GetFiles(@"C:\Something\");
        TableViewModel model = new TableViewModel();
        model.Items = tableNamesPath.Select(item => new SelectListItem
        {
            Value = Path.GetFileName(item),
            Text = Path.GetFileName(item),
        }).ToList();
        return model;
    }
