     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.Red;
            dataGridView1.Rows[e.RowIndex]DefaultCellStyle.BackColor = Color.Red; 
        }
