        public static void QueryTwoFields(string s, List<string> S1, List<string> S2)    
    ///Select into List S1 and List S2 from  Database (2 fields)
                  {
                      try
                      {             
                              MySqlCommand cmd = conn.CreateCommand();
                              cmd.CommandType = CommandType.Text;
                              string command = s;
                              cmd.CommandText = command;
                              MySqlDataReader sqlreader = cmd.ExecuteReader();
                              while (sqlreader.Read())
                              {
                                  S1.Add(sqlreader[0].ToString());
                                  S2.Add(sqlreader[1].ToString());            
                              }
                              sqlreader.Close();
                          }
                      }
                      catch (Exception ex)
                      {                          
                         MessageBox.Show(ex.ToString());            
                      }                                           
                  }
