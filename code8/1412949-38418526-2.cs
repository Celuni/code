    public partial class Form1 : Form
    {
      public void Navigate(string url)
      {
        webBrowser1.Navigate(url);
      }
    
      private void button2_Click(object sender, EventArgs e)
      {
        this.Navigate("https://www.google.com");
      }
    }
