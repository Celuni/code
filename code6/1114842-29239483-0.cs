    String str = "server=localhost;database=population;username=root;password=hello;Convert Zero Datetime=true;";
        MySqlConnection con = new MySqlConnection(str);
        string col1 = col.Text;
        string newval1=newval.Text;
        string val1=val.Text;
        try
        {
            con.Open();
            string cmdstr="update npanxx set "+col1+" = \""+newval1+"\" where NPA_NXX=\""+val1+"\"";
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch(Exception err)
        {
            MessageBox.Show(err.ToString());
        }
