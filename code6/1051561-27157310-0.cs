    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CandidateConnectionString"].ConnectionString);
                    conn.Open();
                    string getdata = "SELECT * FROM Resume WHERE Cand_ID = (SELECT Cand_ID FROM Candidate WHERE Cand_Username = '" + usernamelbl.Text + "')";
                    SqlCommand com = new SqlCommand(getdata, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Resume");
                    Work_Exp.Text = ds.Tables["Resume"].Rows[0]["Work_Experience"].ToString();
                    Edu_Level.Text = ds.Tables["Resume"].Rows[0]["Educational_Level"].ToString();
                    Field_Study.Text = ds.Tables["Resume"].Rows[0]["Field_Of_Study"].ToString();
                    Uni_Name.Text = ds.Tables["Resume"].Rows[0]["University_Name"].ToString();
                    Uni_Locate.Text = ds.Tables["Resume"].Rows[0]["University_Location"].ToString();
                    Year.Text = ds.Tables["Resume"].Rows[0]["Graduation_Year"].ToString();
                    conn.Close();
