    SqlConnection con = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=
        C:\WpfApplication\Database.mdf;Integrated Security=True");
    con.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    con.Open();
    
    SqlCommand cmd = new SqlCommand();
    cmd.CommandText = "UPDATE [People] SET [Number] = 0";
    cmd.Connection = con;
    cmd.ExecuteNonQuery();
