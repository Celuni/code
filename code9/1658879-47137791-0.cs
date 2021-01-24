    // Instantiating a Workbook object
    Workbook workbook = new Workbook();
    
    // Adding a new worksheet to the Excel object
    int sheetIndex = workbook.Worksheets.Add();
    
    // Obtaining the reference of the newly added worksheet by passing its sheet index
    Worksheet worksheet = workbook.Worksheets[sheetIndex];
    
    // Adding sample values to cells
    worksheet.Cells["A1"].PutValue(50);
    worksheet.Cells["A2"].PutValue(100);
    worksheet.Cells["A3"].PutValue(150);
    worksheet.Cells["B1"].PutValue(4);
    worksheet.Cells["B2"].PutValue(20);
    worksheet.Cells["B3"].PutValue(50);
    
    // Adding a chart to the worksheet
    int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Pyramid, 5, 0, 15, 5);
    
    // Accessing the instance of the newly added chart
    Aspose.Cells.Charts.Chart chart = worksheet.Charts[chartIndex];
    
    // Adding SeriesCollection (chart data source) to the chart ranging from "A1" cell to "B3"
    chart.NSeries.Add("A1:B3", true);
    
    // Saving the Excel file
    workbook.Save(dataDir + "output.xlsx");
