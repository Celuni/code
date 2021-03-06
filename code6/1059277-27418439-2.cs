    using(OleDbConnection con = new OleDbConnection(str))
    using(OleDbCommand cmd = con.CreateCommand())
    {
        cmd.CommandText = "UPDATE [users] SET [password] = ? WHERE username = ?";
        cmd.Parameters.Add("pass", OleDbType.VarChar).Value = pwd;
        cmd.Parameters.Add("user", OleDbType.VarChar).Value = userName;
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your password has been changed successfully."); 
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
