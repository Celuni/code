     foreach (DataGridViewRow row in dataGridView1.Rows)
     {
          foreach (DataGridViewCell item in row.Cells)
          {
               if(item.Value == null || item.Value == DBNull.Value || String.IsNullOrWhiteSpace(item.Value.ToString()))
               {
                   item.Value = "0";
               }
          }              
    }
