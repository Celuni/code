        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView list = sender as ListView;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Bounds.Contains(e.Location) == true)
                {
                    list.Items[i].BackColor = Color.Blue; // highlighted item
                }
                else
                {
                    list.Items[i].BackColor = SystemColors.Window; // normal item
                }
            }
        }
