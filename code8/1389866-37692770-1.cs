    Regex pattern = new Regex("^[a-zA-Z]{1,8}$");
    if (pattern.IsMatch(textBox1.Text))
    {
        button1.Text = "Submitted";
        button1.Enabled = false;
        string name = textBox1.Text;
        int ver = 2013;
        MessageBox.Show("Hello " + name + "! Welcome to visual c# " + ver.ToString(), "Greeting");
    }
    else 
    {
        MessageBox.Show("Please type a valid 8 character string on the textbox!");
    }
