            string connString = "my connection string";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("my_sp_name", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = todayDate;
            cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = previousDate;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();            
            return ds;
