        private void btn_Pwd_Click(object sender, EventArgs e)
        {
            try
            {
                string DB_PATH = "Your path to select that existing Excel file";
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(DB_PATH);
                MyBook.Password = "abc";
                MyBook.SaveAs("Your Path to save the copy of that excel which is password protected");
                MyBook.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }
        }
