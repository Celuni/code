    object o = Microsoft.VisualBasic.Interaction.GetObject(@"C:\x.xlsx", "Excel.Application");
    var wb = o as Microsoft.Office.Interop.Excel.Workbook; 
    if (wb != null) 
    { 
        Microsoft.Office.Interop.Excel.Application xlApp = wb.Application;
        // your code 
    }
