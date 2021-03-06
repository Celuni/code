    public class TestViewModel : INotifyPropertyChanged
    {
        private int progress;
        private BackgroundWorker bgWorker;
        private bool isBusy;
        private readonly Dispatcher dispatcher;
        private ObservableCollection<DriveInfo> cdRoms;
        public Int32 Progress
        {
            get { return progress; }
            set
            {
                if (value == progress) return;
                progress = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (value.Equals(isBusy)) return;
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public ICommand ImportCDFilePathCommand
        {
            get
            {
                return new RelayCommand(ImportReagentLotFilePath);
            }
        }
        public ObservableCollection<DriveInfo> CdRoms
        {
            get { return cdRoms; }
            set
            {
                if (Equals(value, cdRoms)) return;
                cdRoms = value;
                OnPropertyChanged();
            }
        }
        // This one made your app crash if you defined it directly in the xaml as datacontext and not were using a viewmodellocator
        public TestViewModel(Dispatcher dispatcher) // ugh I'm sure there is an interface for this, feed your UI dispatcher here
        {
            this.dispatcher = dispatcher;
        }
        // Add this one!
        public TestViewModel()
        {
            this.dispatcher = App.Current.Dispatcher; // Bad pie
        }
        private void ImportReagentLotFilePath()
        {
            IsBusy = true;
            Progress = 0;
            bgWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync(/*whatever parameter you want goes here*/);
        }
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // you are done! 
            Progress = 100;
            CdRoms =  new ObservableCollection<DriveInfo>(e.UserState as IEnumerable<DriveInfo>);
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Notifty your gui changes here forinstance, this method will be called on the gui thread. Just cast/parse what you feed
            Progress = e.ProgressPercentage;
            if (Progress == 100)
                IsBusy = false;
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();                
                bool cdRomExists = allDrives.Any(x => x.DriveType == DriveType.CDRom);
                IEnumerable<DriveInfo> cdroms = allDrives.Where(x => x.DriveType == DriveType.CDRom && allDrives.Any(y => y.IsReady));
                // reports the progress on the ui thread.... 
                bgWorker.ReportProgress(Progress,cdroms);
            }
            catch (Exception ex)
            {
                // errror handling + cancel run
                dispatcher.BeginInvoke((Action) (() => { IsBusy = false; Progress = 0; }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // remove if you are not using R#
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
