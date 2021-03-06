    public static void ClearAllControls(Control.ControlCollection controls)
    {
        foreach (var control in controls)
            ClearAllControls(control);
    }
    public static void ClearAllControls(Control control)
    {			
        var textBox = control as TextBox
        if (textBox != null)
        {
            textBox.Text = null;
            return;
        }
        var comboBox = control as ComboBox;
        if (comboBox != null)
        {
            comboBox.SelectedIndex = -1;
            return;
        }
        // ...repeat blocks for other control types as needed
        ClearAllControls(control.Controls);
    }
