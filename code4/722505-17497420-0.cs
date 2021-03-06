    Task.Factory.ContinueWhenAll(tasks.ToArray(), completedTasks =>
    {
        // callback on UI thread
        UpdateUI(strategy.Slot);
    },
        CancellationToken.None,
        TaskContinuationOptions.Empty,
        TaskScheduler.FromCurrentSynchronizationContext());
