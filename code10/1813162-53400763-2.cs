    public sealed class Config
    {
        private static Config instance = null;
        private static readonly object padlock = new object();
        #region ConfigProperties
        //put public properties here to represent config values
        public int a { get; set; }
        public Dictionary<int, int> b { get; set; }
        #endregion ConfigProperties
        Config()
        {
            ReadConfig();
        }
        public static Config Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Config();
                    }
                    return instance;
                }
            }
        }
        public void ReadConfig()
        {
            //read from your config file and set properties
        }
        public void SaveConfig()
        {
            //write properties back into your config file
        }
    }
