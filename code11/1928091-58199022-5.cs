    private void WriteToLabel()
    {    
        using (SqlConnection conne = new SqlConnection(@"Data Source=LAPTOP-S2J1U9SJ\SQLEXPRESS;Initial Catalog=Unit4_IT;Integrated Security=True"))
        {
            conne.Open();
            string selectQuery = "select sum(Team1) from T_Score;";
            using (SqlCommand com = new SqlCommand(selectQuery, conne))
                label1.Content = Convert.ToString(com.ExecuteScalar());
        }
    }
