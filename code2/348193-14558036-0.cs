        if (!IsPostBack)
        {
            getdata();
        }
    }
    public void getdata()
    {
        ds = objfun12.display();
        repeat12.DataSource = ds;
         repeat12.DataBind();
      
    }
