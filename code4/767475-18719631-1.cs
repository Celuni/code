    class studentHC : Form1
    {
        public studentHC()
        {
            InsertMethod();
        }
        private void InsertMethod()
        {
            MySqlConnection conn; // connection object;
            string connstring = "server=localhost;user Id=root;database=collegesystem;Convert Zero Datetime=True ";
            conn = new MySqlConnection(connstring);
            conn.Open();
            using (var command = new MySqlCommand("SELECT * FROM person", conn))
            {
                using (var myReader = command.ExecuteReader())
                {
                    AddPerson(myReader["personID"]);
                }
            }
        }
    }
