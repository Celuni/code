    private void dataGridView1_CellPainting(object sender,
                                            DataGridViewCellPaintingEventArgs e)
    {
       if (e.ColumnIndex == yourImageColumnIndex)
       {
         e.PaintBackground(e.ClipBounds, true);
         e.PaintContent(e.ClipBounds);
         e.Graphics.DrawString(yourText, dataGridView1.Font, Brushes.Yellow,
                                         e.CellBounds.X, e.CellBounds.Y);
         e.Handled = true;  
       }
    }
