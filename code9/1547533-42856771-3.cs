    private void Checkbox_check()
    {
        if (checkBox1.InvokeRequired)
            checkBox1.Invoke(new Action(Checkbox_check));
        else
        {
            // do what you like to do on the ui context
            //  checkBox1.Checked; // bad here i know, yep...
        }
    }
