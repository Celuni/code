    private void btnSeparate_Click(object sender, EventArgs e)
    {
        // If text, converted to lower-characters contains "stop" -> Exit
        if (txtFullName.Text.ToLower().Contains("stop"))
        {
            // What I understand as "stopping it".
            Application.Exit();
        }
    
        // Your code...
    }
