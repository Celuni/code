    conn.Open();
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conn;
    cmd.CommandText = "select yourSchema.ar_knyga_egzistuoja(@id)";
    cmd.CommandType = CommandType.Text;
    OdbcParameter param = new OdbcParameter();
    cmd.Parameters.Add("id", OracleType.Number).Value = id;
    var result = cmd.ExecuteScalar();
    MessageBox.Show(result);
    cmd.Parameters.RemoveAt(0);
    conn.Close();
