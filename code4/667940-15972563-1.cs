            SqlConnection cnn ;
		    String connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password" 
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show ("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
