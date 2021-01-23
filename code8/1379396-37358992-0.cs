    private void quantityChangeClick(object sender, EventArgs e)
    {
        addToQuantity((Button)sender == this.Add ? 1 : -1);
        updateTotal();
    }
    private void addToQuantity(int howMuch)
    {
        var selectedRowIndices = new List<int>();
        foreach (DataGridViewRow r in dataGridView1.SelectedRows.OfType<DataGridViewRow>())
        {
            selectedRowIndices.Add(r.Index);
        }
        this.rows.Where((r, i) => selectedRowIndices.Contains(i)).ToList().ForEach(
            r =>
            {
                var newValue = r.Quantity + howMuch;
                if (newValue < 0)
                    newValue = 0;
                r.Quantity = newValue;
            });
        this.dataGridView1.Refresh();
    }
    // calculate the total from the data source as well
    private void updateTotal()
    {
        var total = Math.Round(this.rows.Sum(r => r.Quantity * r.Price), 2, MidpointRounding.AwayFromZero);
        this.TotalLabel.Text = string.Format("₱{0:0.00}", total);
    }
