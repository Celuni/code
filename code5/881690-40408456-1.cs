    Private void  inserttoDatagridview()
            {
                try
                {
                    con.Open()
                    (foreach GridViewRow rw in DataGridView1.Rows)
    
    if rw.Cells(0) <> Nothing then
                    {
                        cmd = New SqlCommand("insert into tblEmp (empid,empname,empdesg,dob) values (" & rw.Cells(0).Value & ",'" & rw.Cells(1).Value & "','" & rw.Cells(2).Value & "','" & CDate(rw.Cells(3).Value.ToString()) & "') ", con);
                        cmd.ExecuteNonQuery();
    
    End If
                    }
            }
            catch (Exception ex)
            {
                throw;
            }   
            finally
            {
                con.Close()
            }
        }
