            int i = 0;
            foreach (DataColumn column in dt.Columns)
            {
                CheckBox[] chk = new CheckBox[dt.Columns.Count];
                chk[i] = new CheckBox();
                chk[i].Name = column.ColumnName;
                chk[i].Text = column.ColumnName;
                chk[i].AutoCheck = true;
                chk[i].Bounds = new Rectangle(10, 20 + padding + dynamicHeight, 40, 22);
                panelCol.Controls.Add(chk[i]);
                dynamicHeight += 20;
                panelCol.Size = new Size(120, dynamicHeight);
                panelCol.Controls.Add(chk[i]);
                chk[i].Location = new Point(0, dynamicHeight);
                chk[i].Size = new Size(120, 21);
                panelCol.BackColor = Color.White;
                panelCol.AutoScroll = true;
    
                i++;
                //panelCol.AutoScrollMinSize = new Size (0, 1200);
            }
