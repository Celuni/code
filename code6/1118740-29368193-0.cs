        use this code solve your problem
    it is create datasets fill them with information from queries in EF and bind your crystal report to that dataset.
        
         ReportDocument rptDoc = new ReportDocument();
                    DataSet1 ds = new DataSet1();
                    SqlConnection sqlCon;
                    DataTable dt = new DataTable();
                    dt.TableName = "Crystal Report Example";
                    sqlCon = new SqlConnection("Data Source=TCS3\\SQLEXPRESS;Initial Catalog=db;User ID=sa;Password=sql2008");
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [FirstName],[MiddleName],[LastName],[CurrentSession] FROM [db].[dbo].[addmitionform1]", sqlCon);
                    da.Fill(dt);
                    ds.Tables[0].Merge(dt);
                    rptDoc.Load(Server.MapPath("CrystalReport1.rpt"));
                    rptDoc.SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rptDoc;
