            string sqlConnectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True";
            FileInfo file = new FileInfo(@"D:\Script.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            script = script.Replace("GO", "");
            SqlCommand cmd = new SqlCommand(script, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
