    string queryString = "select Col_Length('Contents','Title') as columnLengthh";
    string connectionString = "Your connection string";
    SqlConnection connection = null;
    try
    {
        connection = new SqlConnection(connectionString)
        using (SqlCommand command = new SqlCommand(queryString, connection)) ;
        {
            connection.Open();
            var result = command.ExecuteScalar();
            Console.WriteLine("columnLengthh = {0}", result);
        }
    }
    finally
    {
        connection.Close();
    }
