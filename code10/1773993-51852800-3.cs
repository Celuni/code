    // Get the panel
    var panel2 = Controls.Find("YourPanel", true).FirstOrDefault() as Panel;
    
    // If it exists
    if (panel2 != null)
    {
        foreach (var button in panel2.obj_uc_MainMenu.Controls.OfType<Button>())
        {
            // Set the value of each one
            button.Enabled = false;
        }
    }
