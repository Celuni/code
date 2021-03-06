        public  void sendEmail(string body)
        {
            if (String.IsNullOrEmpty(email))
                return;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.To.Add("test@gmail.com");
                mail.From = new MailAddress("abc@gmail.com");
                mail.Subject = "sub";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("yourgmail@gmail.com", "Yourpassword"); // ***use valid credentials***
                smtp.Port = 587;
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                print("Exception in sendEmail:" + ex.Message);
            }
        }
