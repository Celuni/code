    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.RowsAdded += (obj, arg) => AutoHeightGrid(dataGridView1);
        dataGridView1.RowsRemoved += (obj, arg) => AutoHeightGrid(dataGridView1);
        //Set data source
        //dataGridView1.DataSource = something;
    }
    void AutoHeightGrid(DataGridView grid)
    {
        var proposedSize = grid.GetPreferredSize(new Size(0, 0));
    dataGridView1.MaximumSize = new Size(this.dataGridView1.Width, 0);
        grid.Height = proposedSize.Height;
    }
