    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string onSubmit = string.Format("prepHtml('{0}','{1}', '{2}';",
                txtEdit.ClientID,
                divEdit.ClientID,
                divHT.ClientID);
    
            Type t = this.GetType();
    
            Page.ClientScript.RegisterOnSubmitStatement(t, t.ToString() + "_getHtml", onSubmit);
        }
    }
