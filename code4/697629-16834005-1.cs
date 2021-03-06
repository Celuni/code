    public IEnumerator<T> GetEnumerator()
    {
        TaskFactory<T> taskFactory = new TaskFactory<T>();
        Task<T> task = null;
        IEnumerator<T> enumerator = Source.GetEnumerator();
        T result = null;
        do
        {
            if (task != null)
            {
                result = task.Result;
                if (result == null)
                    break;
            }
            task = taskFactory.StartNew(() =>
            {
                if (enumerator.MoveNext())
                    return enumerator.Current;
                else
                    return null;
            });
            if (result != null)
                yield return result;
        }
        while (task != null);
    }
