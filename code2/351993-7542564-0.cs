    private void button1_Click(object sender, EventArgs e) {
      using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd = new SqlCommand("sp_Add_contact", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
          cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }
