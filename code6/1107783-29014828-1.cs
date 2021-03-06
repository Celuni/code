    RemoteMySQL mySql = new RemoteMySQL();
    mySql.Connect();
    string sql = "INSERT INTO `table1` SET ";
    sql += "`name` = @name, ";
    sql += "`lastname` = @lastname;";
    MySQLParameters parameters = mySql.Prepare(sql);
    parameters["name"] = name;
    parameters["lastname"] = lastname;
    //mySql.Query(parameters.GetCommand()); not use this.
    list.Add(parameters.GetCommand());
    sql = "INSERT INTO `table2` SET ";
    sql += "`item` = @item, ";
    sql += "`detail` = @detail;";
    parameters = mySql.Prepare(sql);
    parameters["item"] = item;
    parameters["detail"] = detail;
    //mySql.Query(parameters.GetCommand()); not use this.
    list.Add(parameters.GetCommand());
    // And call this method last line.
    mySql.TransactionQuery(list);
