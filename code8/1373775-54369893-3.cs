    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Popup pu = Parent as Popup;
        if ( pu != null )
        {
           DockPanel dp = pu.Parent as DockPanel;
           if (dp != null)
           {
              dp.Children.Remove(pu);
           }
        }
    }
