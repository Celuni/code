    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.ColumnCount = 4;
        dataGridView1.RowCount = 4;
        TextBox txt = null;
        dataGridView1.EditingControlShowing += (s1, e1) =>
        {
            if (dataGridView1.EditingControl is TextBox)
            {
                if (txt == null)
                {
                    txt = (TextBox)dataGridView1.EditingControl;
                    txt.TextChanged += (s2, e2) =>
                    {
                        foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                            cell.Value = txt.Text;
                    };
                }
            }
        };
    }
