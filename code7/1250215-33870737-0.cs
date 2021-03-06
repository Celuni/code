     public Form1()
            {
                InitializeComponent();
                TreeNode node;
                for (int x = 0; x < 3; ++x)
                {
    
                    node = treeView1.Nodes.Add(String.Format("Node{0}", x * 4));
                    for (int y = 1; y < 4; ++y)
                    {
    
                        node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y));
                    }
                }
               
                treeView1.AllowDrop = true;
                treeView1.Dock = DockStyle.Fill;
                treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
                treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
                treeView1.DragOver += new DragEventHandler(treeView1_DragOver);
                treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
            }
            private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
    
                else if (e.Button == MouseButtons.Right)
                {
                    DoDragDrop(e.Item, DragDropEffects.Copy);
                }
            }
    
            private void treeView1_DragEnter(object sender, DragEventArgs e)
            {
                e.Effect = e.AllowedEffect;
            }
            private void treeView1_DragOver(object sender, DragEventArgs e)
            {
                Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
                treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
            }
    
            private void treeView1_DragDrop(object sender, DragEventArgs e)
            {
                Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));      
                if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                    }
                    else if (e.Effect == DragDropEffects.Copy)
                    {
                        targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                    }
    
                    targetNode.Expand();
                }
            }
    
            private bool ContainsNode(TreeNode node1, TreeNode node2)
            {
                if (node2.Parent == null) return false;
                if (node2.Parent.Equals(node1)) return true;
                return ContainsNode(node1, node2.Parent);
            }
