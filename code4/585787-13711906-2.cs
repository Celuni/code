    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10000; i++)
            {
                Persons.Add(new Person());
            }
        }
        private ObservableCollection<Person> myVar = new ObservableCollection<Person>();
        public ObservableCollection<Person> Persons
        {
            get { return myVar; }
            set { myVar= value; }
        }
    }
    public class Person 
    {
        // ...
        UIElement _UI;
        public UIElement UI
        {
            get
            {
                if (_UI == null)
                {
                    ParallelGenerateUI();
                }
                return _UI;
            }
        }
        private void ParallelGenerateUI()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate()
            {
                _UI = GenerateUI();
                // RaisePropertyChanged("UI");
            });
        }
        private UIElement GenerateUI()
        {
            Random rnd = new Random();
            var tb = new TextBlock();
            tb.Width = 800.0;
            tb.TextWrapping = TextWrapping.Wrap;
            var n = rnd.Next(10, 5000);
            for (int i = 0; i < n; i++)
            {
                tb.Inlines.Add(new Run("A line of text. "));
            }
            return tb;
        }
        // ...
    }
