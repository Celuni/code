    private void button1_Click(object sender, EventArgs e)
    {
      OleDbConnection connection = new OleDbConnection();
      connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=names.mdb";
      connection.Open();
     
      foreach (Control control in Controls)
      {
        if (control is Label)
        {
          OleDbCommand command = new OleDbCommand();
          command.Connection = connection;
          command.CommandText = "SELECT nickname FROM names ORDER BY rnd(ID)";
          OleDbDataReader reader = command.ExecuteReader();
          reader.Read();
          control.Text = reader["nickname"].ToString();
        }
      }
      connection.Close();
    }
