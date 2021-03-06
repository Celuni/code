    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
    	RadioButton rb = sender as RadioButton;
    	if (rb != null && rb.Checked)
    	{
    		int count = 0;
    		int txtBoxVisible = 3;
            HideAllTextBox();
    		foreach (Control c in Controls)
    		{
     		    if(count > txtBoxVisible) break;
	
                TextBox textBox = c as TextBox;
                if (count <= txtBoxVisible && textBox != null)
    			{
		     	    textBox.Visible = true; 
    			    count++;
    			}
    		}
    	}
    }
    
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
    	RadioButton rb = sender as RadioButton;
    	if (rb != null && rb.Checked)
    	{
            HideAllTextBox();
    		foreach (Control c in Controls)
    		{
    			TextBox textBox = c as TextBox;
    			if (textBox != null) textBox.Visible = true; 
    		}
    	}
    }
	private void HideAllTextBox()
	{
		foreach (Control c in Controls)
		{
			TextBox textBox = c as TextBox;
			if (textBox != null) textBox.Visible = false; 
		}
	}
