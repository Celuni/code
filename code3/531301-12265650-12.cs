    var TblSub = new DataTable();
    var TblMain = new DataTable();
    TblSub.Columns.Add("FeeID", typeof(int));
    TblSub.Columns.Add("Amount", typeof(int));
    TblSub.Columns.Add("FeeItem", typeof(string));
    TblSub.Columns.Add("Type", typeof(char));
    TblMain.Columns.Add("FeeID", typeof(int));
    TblMain.Columns.Add("Amount", typeof(int));
    TblMain.Columns.Add("FeeItem", typeof(string));
    TblMain.Columns.Add("Type", typeof(char));
    TblSub.Rows.Add(10, 7500, "Admission Free", 'T');
    TblSub.Rows.Add(10, 900, "Annual Fee", 'T');
    TblSub.Rows.Add(10, 150, "Application Free", 'T');
    TblSub.Rows.Add(10, 850, "Boy's Uniform", 'T');
    TblSub.Rows.Add(10, 50, "Computer Free", 'R');
    TblMain.Rows.Add(9, 8500, "Admission Free", 'T');
    TblMain.Rows.Add(9, 950, "Annual Fee", 'T');
    TblMain.Rows.Add(9, 150, "Application Free", 'T');
    TblMain.Rows.Add(9, 850, "Boy's Uniform", 'T');
    TblMain.Rows.Add(9, 50, "Computer Free", 'R');
    TblMain.Rows.Add(10, 7500, "Admission Free", 'T');
    TblMain.Rows.Add(11, 900, "Annual Fee", 'T');
    TblMain.Rows.Add(11, 150, "Application Free", 'T');
    TblMain.Rows.Add(11, 850, "Boy's Uniform", 'T');
    TblMain.Rows.Add(11, 50, "Computer Free", 'R');
