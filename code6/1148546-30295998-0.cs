    var pro = from p in lstprocess
                 //where p.ProcessName.Contains("LRCDual")
                 //where p.ProcessName.Contains(ds.Tables[0].Rows[k].ItemArray)  //added temporary
                 where (p.ProcessName.Contains(ds.Tables[0].Rows[0].ItemArray[k].ToString()))
                 select p; 
