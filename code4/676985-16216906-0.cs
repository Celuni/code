    private void RegisterInStartup(bool isChecked)
    {
       RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
       if (isChecked)
       {
           registryKey.SetValue("ApplicationName", Application.ExecutablePath);
       }
       else
       {
         registryKey.DeleteValue("ApplicationName");
       }
    }
