        List<Business> businessCollection = new List<Business>();
        protected List<Business> GetBusinesses()
        {
            if (Session["Business"] == null) 
                return businessCollection;
            else 
                return (List<Business>)Session["Business"];
        }
        protected void btnRow_Click(object sender, EventArgs e)
        {            
            Business b = new Business();
            b.BusinessNo = Convert.ToInt32(txtBNo.Text);
            b.BusinessName = txtBName.Text;
            b.BusinessDescription = txtBDesc.Text;
            var currentCollection = GetBusinesses();
            currentCollection.Add(b);
            GridView1.DataSource = currentCollection;
            GridView1.DataBind();
        }
