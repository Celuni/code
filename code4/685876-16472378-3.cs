    string strAccountID = "A1234"; //Create the variable and assign a value to it
    string AcctID = strAccountID.Substring(0, 10);
    oCn = new SqlConnection(ConfigurationSettings.AppSettings["GBRegistrationConnStr"].ToString());
    oCn.Open();
    oCmd = new SqlCommand();        
        
    oCmd.CommandText = sSQL;
    oCmd.Connection = oCn;
    oCmd.CommandType = CommandType.Text;
    ocmd.Parameters.Add("straccountid", AcctID); //<-- You forgot to add in the parameter
    oDR = oCmd.ExecuteReader(CommandBehavior.CloseConnection);
