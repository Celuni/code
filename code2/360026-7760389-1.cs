    using(SqlConnection myConnection = new SqlConnection(myconnectionString))
    { 
        SqlCommand myCommand = new SqlCommand(); 
        myCommand.CommandType = CommandType.StoredProcedure; 
        myCommand.CommandText = "usp_GetCustomer";     
        myCommand.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = sUserName;    // user name that you pass to stored procedure
        myCommand.Parameters.Add("@Month", SqlDbType.VarChar).Value = iMonth;    // Month that you pass to stored procedure
        // to get return value from stored procedure
        myCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;     
        myConnection .Open();
        myCommand.ExecuteScalar();     
        // Returnvalue from stored procedure
        return Convert.ToInt32(command.Parameters["@ReturnValue"].Value); 
    }
