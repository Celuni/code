    public partial class MainPage : UserControl//,INotifyPropertyChanged
    {
        ObservableCollection<UserData> users = new ObservableCollection<UserData>();
        public MainPage()
        {
            Service1Client client = new Service1Client();
            client.GetUsersCompleted += completed;
          //  client.GetDataCompleted += completed;
          //  client.GetDataAsync(5);
            client.GetUsersAsync(5);
            InitializeComponent();
            image.Source = new BitmapImage(new Uri(@"c:\1.JPG"));
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string name)
        //{
        //    if (PropertyChanged == null) return;
        //    var args = new PropertyChangedEventArgs(name);
        //    PropertyChanged(this, args);
        //}
        
        private void completed(object sender, GetUsersCompletedEventArgs e)
        {
            users=e.Result;
            UsersList.ItemsSource = users;
        }
        private void SelectionChngd(object sender, SelectionChangedEventArgs e)
        {
            UserData u= (UserData)(UsersList.SelectedItem);
            DescText.Text = u.Desc;
            image.Source =
                new BitmapImage(new Uri(@"http://profile.ak.fbcdn.net/hprofile-ak-snc4/49939_713180125_9000_q.jpg"));
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (UsersList.SelectedItem != null)
            {
                UserData u = (UserData)(UsersList.SelectedItem);
                DescText.Text = u.Desc;
            }
        }
    }
}
