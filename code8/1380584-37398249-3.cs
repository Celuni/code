    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space &&
                     ((e.Modifiers & Keys.Shift) != 0) &&  // *
                     ((e.Modifiers & Keys.Control) != 0))  
        {
            char nbrsp = '\u2007';             // non-breaking space
            char zerospacebinding = '\u200B';  // zero space
            char zerospacebinding = '\u200D';  // zero space with binding
            int s = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(s, nbrsp.ToString());
            e.Handled = true;
            textBox1.SelectionStart = s + 1;
        }
    }
