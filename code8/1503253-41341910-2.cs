    var param1 = new SqlParameter(); 
    param1.ParameterName = "@Value1"; 
    param1.SqlDbType = SqlDbType.Int; 
    param1.SqlValue = val1;
    
    var param2 = new SqlParameter(); 
    param2.ParameterName = "@Value2"; 
    param2.SqlDbType = SqlDbType.NVarChar; 
    param2.SqlValue = val2;
    
    var result = db.tablename.SqlQuery("SP_Name @Value1,@Value2", param1, param2 ).ToList();
