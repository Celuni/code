    protected void menu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
     {
          string value = (e.Item.Value).ToString();
          string strConn = ConfigurationManager.ConnectionStrings["ConnectionStrings:ProgSQL"].ConnectionString; 
          SqlDataSource WtrClientDS = new SqlDataSource(); 
          WtrClientDS.ConnectionString = strConn;
          WtrClientDS.SelectCommand = "SELECT * from Prog where ProgId = @LocId"
          WtrClientDS.SelectParameters.Add(new Parameter("LocId", System.TypeCode.String, value));
         
          //refresh your control
          WtrClients.DataSource = WtrClientDS.Select(DataSourceSelectArguments.Empty);
          WtrClients.Rebind();
     }
