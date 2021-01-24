    DataSet dataSet = new DataSet("dataSet");
    dataSet.Namespace = "NetFrameWork";
    DataTable table = new DataTable();
    DataColumn idColumn = new DataColumn("id", typeof(int));
    idColumn.AutoIncrement = true;
    
    DataColumn itemColumn = new DataColumn("item");
    table.Columns.Add(idColumn);
    table.Columns.Add(itemColumn);
    dataSet.Tables.Add(table);
    
    for (int i = 0; i < 2; i++)
    {
        DataRow newRow = table.NewRow();
        newRow["item"] = "item " + i;
        table.Rows.Add(newRow);
    }
    
    dataSet.AcceptChanges();
    
    string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
    
    Console.WriteLine(json);
    
    //{
         // "Table1": [
         //   {
          //    "id": 0,
         //     "item": "item 0"
         //   },
         //   {
         //    "id": 1,
         //     "item": "item 1"
         //   }
         //  ]
        //"Table2": [
          //  {
           //   "id": 0,
           //   "item": "item 0",
             // "rate": 200.00
           // },
           // {
            // "id": 1,
            //  "item": "item 1",
            //   "rate": 225.00
            //}
          // ]
        
       // "Table3": [
           // {
           //   "id": 0,
           //   "item": "item 0",
           //   "rate": 200.00,
           //   "UOM" : "KG"
           // },
           // {
           //  "id": 1,
           //   "item": "item 1",
           //    "rate": 225.00,
           //   "UOM" : "LTR"
           // }
          // ]
         //}
    
      
