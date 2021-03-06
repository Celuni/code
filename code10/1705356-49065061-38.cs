      SystemMenu systemMenu;
      Bitmap _MenuIcon;
      //In a Form contructor
      { 
          systemMenu = new SystemMenu(this);
          _MenuIcon = new Bitmap(Properties.Resources.[Some 16x16 Bitmap]);
          systemMenu.InsertCommand(0, "Bitmap Menu", _MenuIcon.GetHbitmap(), OnSysBitmapMenu);
          systemMenu.AddCommand("&About…", OnSysMenuAbout, true);
      }
       // Handle menu command click
      private void OnSysMenuAbout()
      {
          MessageBox.Show("My about message");
      }
      private void OnSysBitmapMenu()
      {
          MessageBox.Show("My other bitmap menu message");
      }
      protected override void WndProc(ref Message msg)
      {
          base.WndProc(ref msg);
          // Let it know all messages so it can handle WM_SYSCOMMAND
          // (This method is inlined)
          systemMenu.HandleMessage(ref msg);
      }
