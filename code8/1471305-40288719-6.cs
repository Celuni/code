    public class TaskWrapper
    {
        public TaskWrapper(string operationID, Task task, CancellationTokenSource cancellationSource)
        {
            this.OperationID = operationID;
            this.Task = task;
            this.CancellationSource = cancellationSource;
        }
        public string OperationID { get; set; }
        public Task Task { get; set; }
        public CancellationTokenSource CancellationSource { get; set; }
    }
    
    
    private Dictionary<Guid, TaskWrapper> ListOfTasks = new Dictionary<Guid, TaskWrapper>();
    // populate the list
    
    public void CancelAll(string operation)
    {
        listOfTasks.Where(a => a.OperationID == operation).CancellationSource.Cancel();
    }
