       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
       {
          connection.Open();
          using (SqlCommand cmd = connection.CreateCommand())
          {
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "....";
             
             using (SqlDataReader reader = cmd.ExecuteReader())
             {
                while (reader.Read())
                {
                   //etc
                }
             }
          }
       }
