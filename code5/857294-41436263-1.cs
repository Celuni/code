    private void treeView1_Enter(object sender, EventArgs e)
    {
       if (treeView1.SelectedNode != null)
       {
           treeView1.SelectedNode.BackColor = Color.Empty;
           treeView1.SelectedNode.ForeColor = Color.Empty;
       }
    }
    private void treeView1_Leave(object sender, EventArgs e)
    {
       if (treeView1.SelectedNode != null)
       {
           treeView1.SelectedNode.BackColor = SystemColors.Highlight;
           treeView1.SelectedNode.ForeColor = Color.White;
       }
    }
