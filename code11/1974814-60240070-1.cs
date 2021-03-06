    public partial class MainWindow : Window 
    {
        private Button _newBtn;
        public MainWindow()
        {
            InitializeComponent();
            _newBtn = new Button();
            _newBtn.Content = "Test";
            _newBtn.Name = "btnTest";  // < the name is not needed, because you already have a reference. (so you don't have to use FindControl)
            // and if you want to register the click event.
            _newBtn.Click += Button_Click;
            spTest.Children.Add(_newBtn);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked");
        }
        private void WPFButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //I want to access the button called btnTest and display the name of the button             
            _newBtn.Content = "Test2"; 
        }
    }
