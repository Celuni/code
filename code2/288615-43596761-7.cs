    public bool Update(YourClass yourClass)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            return conn.Update(yourClass) ;
        }
    }
