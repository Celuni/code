    TabItem ti = null;
    ti.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
     {
       ti = new TabItem();
       ti.Header = saha.SahaAdı + " (" + saha.SahaTipi + ")";
       ti.Content = ug;
      });
