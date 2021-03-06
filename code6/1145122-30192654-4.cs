    using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT FROM rookstayers where name = @name";
                        MySqlDataReader reader = command.ExecuteReader();
    
                        foreach (var rooker in Players)
                        {
                            while (reader.Read())
                            {
                                if (reader.Read())
                                {
                                    command.CommandText = @"UPDATE rookstayers SET onlinestatus CASE WHEN name = @name THEN 1 ELSE 0 END;UPDATE rookstayers SET level = 0 WHERE name = @name";
                                    command.ExecuteNonQuery();
                                }
                                else
                                {
                                    command.CommandText = @"INSERT INTO rookstayers (name, sex, vocation, level, achievements, world, lastlogin, accountstatus, onlinestatus) VALUES (@name, @sex, @vocation, @level, @achievements, @world, @lastLogin, @accountStatus, @onlineStatus)";
                                    command.ExecuteNonQuery();
                                }
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@name", rooker.Name);
                                    command.Parameters.AddWithValue("@sex", rooker.Sex);
                                    command.Parameters.AddWithValue("@vocation", rooker.Vocation);
                                    command.Parameters.AddWithValue("@level", rooker.Level);
                                    command.Parameters.AddWithValue("@achievements", rooker.Achievements);
                                    command.Parameters.AddWithValue("@world", rooker.World);
                                    command.Parameters.AddWithValue("@lastLogin", rooker.LastLogin);
                                    command.Parameters.AddWithValue("@accountStatus", rooker.AccountStatus);
                                    command.Parameters.AddWithValue("@onlineStatus", rooker.OnlineStatus);
                            }
                        }
                        Players.Clear();
                    }
                    connection.Close();
                }
