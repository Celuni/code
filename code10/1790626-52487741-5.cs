    private void dataGridView1_CellPainting(object sender,
                                            DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 2 && e.RowIndex == 6)
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        if (e.ColumnIndex == 2 && e.RowIndex == 1)
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        if (e.ColumnIndex == 4 && e.RowIndex == 4)
        {
            e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        }
    }
