    /// <summary>
    /// a very simple ICommand implementation
    /// </summary>
    public class BasicCommand: ICommand
    {
        private readonly Action _execute;
        public BasicCommand(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
        public event EventHandler CanExecuteChanged;
    }
