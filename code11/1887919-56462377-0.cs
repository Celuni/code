    public class perRelayCommandAsync : ObservableObject, ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        public perRelayCommandAsync(Func<Task> execute) : this(execute, () => true ) { }
        public perRelayCommandAsync(Func<Task> execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                if(Set(nameof(IsExecuting), ref _isExecuting, value))
                    RaiseCanExecuteChanged();
            }
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => !IsExecuting 
                                                    && (_canExecute == null || _canExecute());
        public async void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;
            IsExecuting = true;
            try
            {
                await _execute().ConfigureAwait(true);
            }
            finally
            {
                IsExecuting = false;
            }
        }
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
