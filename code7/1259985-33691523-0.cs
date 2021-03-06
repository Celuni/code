    public partial class ConfigSetting : Window, INotifyPropertyChanged
    {
        private string lbIsVisible;
        public ConfigSetting()
        {
            InitializeComponent();
            LbIsVisible = "Hidden";
            DataContext = this;
        }
     public string LbIsVisible
     {
            get { return lbIsVisible; }
            set
            {
                if (lbIsVisible != value)
                {
                    lbIsVisible = value;
                    OnPropertyChanged("lbIsVisible");
                }
            }
    }
    protected void OnPropertyChanged(string propertyName)
    {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    }
    private void chkSelectVessel_Checked(object sender, RoutedEventArgs e)
    {
         this.LbIsVisible = "Visible";
    }
