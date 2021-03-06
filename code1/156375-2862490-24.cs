    private static IEnumerable<IDataRecord> Retrieve(string sql, Action<SqlCommand> addParameters)
    {
        //ConnectionString is a private static property in the data layer
        // You can implement it to read from a config file or elsewhere
        using (var cn = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(sql, cn))
        {
            addParameters(cmd);
    
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                    yield return rdr;
                rdr.Close();
            }
        }
    }
