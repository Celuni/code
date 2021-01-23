    public class DelegateDisposable : IDisposable
    {
        private readonly Action action;
        public DelegateDisposable(Action action)
        {
            this.action = action;
        }
        public void Dispose()
        {
            if(this.action != null)
            {
                this.action();
            }
        }
    }
