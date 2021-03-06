    static void Main(string[] args)
    {
        // Instantiate the connection
        using (SqlConnection cnnUserMan = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\Program Files\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\MSSQL\\DATA\\UserDB.mdf; Integrated Security=True;Connect Timeout=30;User Instance=True"))
        using (SqlCommand cmmUser = cnnUserMan.CreateCommand())
        {
            // Initialize command
            cmmUser.CommandText = "SelectID";
            cmmUser.CommandType = CommandType.StoredProcedure;
            cnnUserMan.Open();
            using (SqlDataReader dr = cmmUser.ExecuteReader())
            {
                // Loop through returned rows
                while (dr.Read())
                {
                    // Loop through all the returned columns
                    // Printing column name and value
                    for (int col = 0; col < dr.FieldCount; col++)
                    {
                        Console.WriteLine(dr.GetName(col) + " = " + dr.GetValue(col));
                    }
                    Console.WriteLine();
                }
            }
        }
        Console.ReadLine();
    }
