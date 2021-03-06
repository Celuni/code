    private static void SmtpServer_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                MailMessage thisMesage = (MailMessage) e.UserState;
                if (e.Error != null)
                {
                    if (e.Error.InnerException != null)
                    {
                        writeMessage("ERROR: Sending Mail: " + thisMesage.Subject + " Msg: "
                                     + e.Error.Message + e.Error.InnerException.Message);
                    }
    
                    else
                    {
                        writeMessage("ERROR: Sending Mail: " + thisMesage.Subject + " Msg: " + e.Error.Message);
                    }
                }
                else
                {
                    writeMessage("Success:" + thisMesage.Subject + " sent.");
                }
                _autoResetEvent.Set();//Here is the event reset
                mailWaiting--;
            }
