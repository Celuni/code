                    SqlDataAdapter da = new SqlDataAdapter(); 
                    da.SelectCommand = cmd; 
                    DataTable dt= new DataTable();
                    dt.TableName = "Data";
                    da.Fill(dt); 
                    GridView gv = new GridView(); 
                    gv.DataSource = dt; 
                    gv.DataBind(); 
                    gv.AutoGenerateColumns = true; 
                    gv.CellPadding = 2; 
                    gv.CellSpacing = 2; 
                    gv.ShowHeader = false; 
                    Controls.Add(gv);
