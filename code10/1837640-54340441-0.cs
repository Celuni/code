    private void Ring_Load(object sender, EventArgs e)
        {
            showdata();
            showmedal();  
        }
    
        void showdata()
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT Number,Weight,Ring_Id FROM Ring", con);
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[3].Visible = false;
    
        }
        void showmedal()
        {
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT Number,Weight,Ring_Id FROM medal", con);
            da.SelectCommand = cmd;
            dt.Clear();
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
