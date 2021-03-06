    List<DataGridViewRow> l = new List<DataGridViewRow>();
    foreach (DataGridViewRow r in dgv.Rows)
    {
    	l.Add(r);
    }
    
    l.Sort((x, y) =>
    	{
    		IComparable yComparable = (IComparable)x.Cells[dgv.SortedColumn.Index].Value;
    		IComparable yc = (IComparable)x.Cells[dgv.SortedColumn.Index].Value;
    
    		if (dgv.SortOrder == SortOrder.Ascending)
    			return yComparable.CompareTo(yc);
    		else
    			return yc.CompareTo(yComparable);
    	}
    	);
    
    foreach(DataGridViewRow r in dgv.SelectedRows)
    {
    	int selectedIndex = l.IndexOf(r);
    }
