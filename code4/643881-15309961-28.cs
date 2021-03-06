    container.RegisterSingle<IEnumerable<IFileWatcher>>(() =>
    {
        return
            from 
        var list = new List<IFileWatcher>
        {
            new FileWatcher(@".\Triggers\TriggerWatch\SomeTrigger.txt", container.GetInstance<IFileSystem>()),
            new FileWatcher(@".\Triggers\TriggerWatch\SomeOtherTrigger.txt", container.GetInstance<IFileSystem>())        
        };
        
        return list.AsReadOnly();
    });
