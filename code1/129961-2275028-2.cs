    lock(syncLock)
    {
        // Timestamp is generated here...
        var stateHistoryItem = new RequestStateHistoryItem(state, this);
        // ... but an indeterminate time can pass before ...
        ...
        // ... it's added to the collection here.
        stateHistoryItems.Add(stateHistoryItem);
    }
