    private void someToolStripMenuItem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar== 'x')
        {
            var item = (ToolStripItem)sender;
            item.Visible = false;
            var owner = (ToolStrip)(item.Owner);
            owner.Visible = owner.Items.Cast<ToolStripItem>().Any(x => x.Visible);
        }
    }
