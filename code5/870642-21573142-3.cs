    private void ComputeBySalesSalesID(DataSet dataSet)
    {
             if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow drSum = ds.Tables[1].Rows[0];
                        GridViewRow footer = dgOpenBal.FooterRow;
                        var lblTotal = (Label)footer.FindControl("lblTotal");
                        lblTotal.Text = drSum["sum"].ToString();
                    }
    }
