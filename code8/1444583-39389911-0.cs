    public static class Settings 
    {
    
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
    
        //Setting Constants
    
        const string UserName = "username";
        private static readonly string UserNameDefault = string.Empty;
        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault<string>(UserName, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserName, value); }
        }
    }
