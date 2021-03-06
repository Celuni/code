    private bool isChildCheck = false;
    private void TREE_VIEW_AfterCheck(object sender, TreeViewEventArgs e)
    {
        // The code only executes if the user caused the checked state to change.
        if (e.Action != TreeViewAction.Unknown)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (isChildCheck)
                {
                    isChildCheck = false;
                    return;
                   //This will check the parent to exit AfterCheck loop
                }
                // Calls the CheckAllChildNodes method, passing in the current 
                // checked value of the TreeNode whose checked state changed. 
                CheckAllChildNodes(e.Node, e.Node.Checked);
            }
            else
            {
                e.Node.Parent.Checked = GetCheckStateOfChildNodes(e.Node.Parent);
                isChildCheck = !GetCheckStateOfChildNodes(e.Node.Parent);
            }
        }
    }
    //After a tree node's Checked property is changed, all its child nodes are updated to the same value.
    private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
    {
        foreach (TreeNode node in treeNode.Nodes)
        {
            node.Checked = nodeChecked;
            if (node.Nodes.Count > 0)
            {
                // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                CheckAllChildNodes(node, nodeChecked);
            }
        }
    } //Checks the childnodes of a node recursively
    //Additional Method to react on behavior when all childs are checked/unchecked
    //This part was added by dwza and is not in the VB part
    private bool GetCheckStateOfChildNodes(TreeNode treeNode)
    {
        foreach(TreeNode node in treeNode.Nodes)
        {
            if (node.Checked)
            {
                return true;
            }
        }
        return false;
    }
