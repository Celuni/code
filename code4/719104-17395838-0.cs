    using(var connection = new SqlConnection(formConnectionString))
                {
                    connection.Open();
    
                    using (var command = new SqlCommand("sp_ConsultarCuenta", connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", params.Nombre);
    
                        command.CommandType = CommandType.StoredProcedure;
    
                        command.ExecuteNonQuery();
                    }
    
                    connection.Close();
                }
