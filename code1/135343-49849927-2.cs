    splitBox.Panel1.BackColor = splitBox.Panel1.BackColor;
    splitBox.Panel2.BackColor = splitBox.Panel2.BackColor;
    splitBox.BackColor = yourFavouriteColor;
    splitBox.SplitterWidth = yourFavouriteSize;
    splitBox.TabStop = false;
    splitBox.MouseUp += (s, e) => splitBox.ActiveControl = splitBox.Panel1;
