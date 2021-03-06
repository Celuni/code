    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using MySql.Data.MySqlClient;
    
    namespace TransDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string DB_CONN_STR = "Persist Security Info=False;Username=foo_dbo;Password=pass;database=foo_db;server=localhost;Connect Timeout=30";
                const int DB_TIMEOUT = 30;
    
                MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
                MySqlCommand cmd = null;
                MySqlTransaction trx = null;
    
                Console.WriteLine("Updating...");
    
                try
                {
                    cn.Open();
                    string sqlCmd = "update users set username = @username where user_id = @user_id";
    
                    cmd = new MySqlCommand(sqlCmd, cn);
    
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = DB_TIMEOUT;
    
                    cmd.Parameters.AddWithValue("@username", "beta");
                    cmd.Parameters.AddWithValue("@user_id", 2);
    
                    cmd.Prepare();
    
                    trx = cn.BeginTransaction();
                    cmd.Transaction = trx;
                                    
                    cmd.ExecuteNonQuery();
    
                    trx.Commit();
    
                    Console.WriteLine("Update complete");
                }
                catch (Exception ex)
                {
                    if(trx != null) trx.Rollback();
                    Console.WriteLine("oops - {0}", ex.Message);
                }
                finally
                {
                    cn.Dispose();
                }
                Console.WriteLine("Press any key to quit");
                Console.ReadKey();
            }
        }
    }
