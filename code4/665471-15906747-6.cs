     public class Folder : INotifyPropertyChanged
            {
            
            public Folder(string folderName) 
                {
                Folders = new ObservableCollection<Folder>();
                var _ifs = IsolatedStorageFile.GetUserStoreForApplication();
                if (folderName != null)
                    {
                    Folders = new ObservableCollection<Folder>(
                            (from c in _ifs.GetDirectoryNames(folderName + "\\*.*")
                             select new Folder(c)
                       ));
                    }
                else
                    {
                    Folders = new ObservableCollection<Folder>(
                           (from c in _ifs.GetDirectoryNames()
                            select new Folder(c)
                      ));
                    }
                }
            public string Name { get; set; }
            private ObservableCollection<Folder> _Folders; 
            public ObservableCollection<Folder> Folders 
                {
                get
                { return _Folders; }
                set { _Folders = value; OnPropertyChanged("RootFolder"); }
                }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
                {
                if (PropertyChanged != null)
                    {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                    }
                }
            #endregion
        }
    public partial class OpenFileDialog : UserControl
        {      
        public OpenFileDialog()
            {
            InitializeComponent();
            RootFolder = new Folder (null);            
            FolderTreeView.DataContext = this;
            }
        private Folder _RootFolder;
        public Folder RootFolder
            {
            get { return _RootFolder; }
            set { _RootFolder = value; }
            }        
        }
