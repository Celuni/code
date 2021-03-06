            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.IsMenuEnabled = false;
            ApplicationBarIconButton addBtn = new ApplicationBarIconButton(new Uri("BarIcons/add.png", UriKind.Relative));
            addBtn.Text = "Add";
            addBtn.Click += addBtn_Click;
            ApplicationBarIconButton infoBtn = new ApplicationBarIconButton(new Uri("BarIcons/info.png", UriKind.Relative));
            infoBtn.Text = "Info";
            infoBtn.Click += infoBtn_Click;
            ApplicationBar.Buttons.Add(addBtn);
            ApplicationBar.Buttons.Add(infoBtn);
