    Parallel.ForEach(DT.Rows.OfType<System.Data.DataRow>(), (DataRow row2, ParallelLoopState loopState, long i) =>
    {
        try {
            bool check = (urlcheck(dataGridView.Rows[i].Cells[2].Value.ToString()));
            if (check == true)
                ExecuteQuery("");
            else
                ExecuteQuery("");
        }
        catch{ }
    });
