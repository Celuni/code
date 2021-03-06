    private void CustInvLines_CellFormatting(object sender,
                                             DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        var column = CustInvLines.Columns[e.ColumnIndex];
        if (column.Name == "InvLinePrice")
        {
            var cell = CustInvLines.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (decimal)e.Value;
            if (cell.IsInEditMode)
            {
                e.Value = value.ToString(); // Display all digits
            }
            else
            {
                // Display only two digits of decimals without rounding
                var twoDigitsValue = Math.Truncate(value * 100)/100;
                e.Value = twoDigitsValue.ToString("C2");
            }
        }
    }
