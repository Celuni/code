        protected void Page_Load(object sender, EventArgs e)
        {
            this.countMe();
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
            lblCounter.Text = tmpDs.Tables[0].Rows[0]["hits"].ToString();
        }
        private void countMe()
        {
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
            int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());
            hits += 1;
            tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();
            tmpDs.WriteXml(Server.MapPath("~/counter.xml"));
        }
