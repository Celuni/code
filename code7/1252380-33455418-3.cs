    public IList<ChatMessage> GetAll(string fName)
        {
            var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            ChatMessage _chatMessage = new ChatMessage();
            IList<ChatMessage> _all_chatMessages = new List<ChatMessage>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from kb_Chat_Message";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);         
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {    
                        _chatMessages.RequiredField = oReader["RequiredFieldname"].ToString();                     
 
