    protected void Page_Load(object sender, EventArgs e)
    {
        Menu Menu = (Menu)Page.Master.FindControl("NavigationMenuAdmin");
        Menu.MenuItemClick +=Menu_MenuItemClick;
    }
    void Menu_MenuItemClick(object sender, MenuEventArgs Events)
    {
        Menu Menu = (Menu)sender;
        MenuItem selectedItem = Menu.SelectedItem;
        Response.Write("Selected Item is: " + Menu.SelectedItem.Text + ".");
    }
