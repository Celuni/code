    private void button1_Click_1(object sender, EventArgs e)
    {
        DataGridViewRow dr = dataGridView1.SelectedRows[0];
        dtItems.Columns.Add("city_ID");
        dtItems.Columns.Add("city_Name");
        dtItems.Columns.Add("status");
        dtItems.Columns.Add("date");
        if (dataGridView1.Rows.Count > 1)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    DataRow row;
                    row = dtItems.NewRow();
                    
                    row["city_ID"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    row["city_Name"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    row["status"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    row["date"] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    
                    dtItems.Rows.Add(row);
                }
            }
        }
        Form2 frm = new Form2(dtItems);
        frm.ShowDialog();
    }
