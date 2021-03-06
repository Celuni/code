    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;
    namespace LearningTol
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private async void btnSend_Click(object sender, EventArgs e)
            {
                foreach(ListViewItem email in lvEmails.Items)
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(tbUsername.Text);
                    msg.To.Add(new MailAddress(email.Text));
                    msg.Subject = "Subject";
                    msg.Body = tbMessage.Text;
                    msg.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(tbUsername.Text, tbPassword.Text);
                    client.EnableSsl = true;
                    await client.SendAsync(msg);
                    ListViewItem lvi = new ListViewItem(email.Text);
                    lvi.SubItems.Add("Done!");
                    lvFinishedEmails.Items.Add(lvi);
                }
            }
        }
    }
