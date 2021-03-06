    try
    {
    	using (SqlConnection conn = new SqlConnection("Your Connection String Name")) // WebConfig
    	using (SqlCommand nonqueryCommand = conn.CreateCommand())
    	{
    		conn.Open();
    		
    		StringBuilder sqlBuilder = new StringBuilder();
    		sqlBuilder.AppendLine(" INSERT INTO customer ");
    		sqlBuilder.AppendLine(" (firstName, lastname) ");
    		sqlBuilder.AppendLine(" VALUES ");
    		sqlBuilder.AppendLine(" (@firstName, @lastname)");
    		
    		nonqueryCommand.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 50)).Value = "Brad";
    		nonqueryCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 50)).Value = "Test";
    		
    		nonqueryCommand.CommandText = sqlBuilder.ToString();
    
    	   nonqueryCommand.ExecuteNonQuery();
       }   
    }
    catch (Exception ex)
    {
    	...
    }
