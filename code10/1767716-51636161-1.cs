    [Fact]
    public void TestMethod1()
    {
        var objectList = new ReactiveList<IMyObject>(
            initialContents: new[] { new MyObject(), new MyObject() },
            resetChangeThreshold: 0.3,
            scheduler: ImmediateScheduler.Instance);
        objectList.ChangeTrackingEnabled = true;
        IMyViewModel myViewModel = new MyViewModel
        {
            ObjectList = objectList,
            MyObject = new MyObject()
        };
        var canExecute = myViewModel.Save
            .CanExecute
            .CreateCollection(scheduler: ImmediateScheduler.Instance);
        Assert.Equal(1, canExecute.Count);
        Assert.False(canExecute[0]);
        myViewModel.ObjectList[0].Active = true;
        Assert.Equal(2, canExecute.Count);
        Assert.True(canExecute[1]);
        myViewModel.MyObject.Active = true;
        Assert.Equal(2, canExecute.Count);
        myViewModel.IsBusy = true;
        Assert.Equal(3, canExecute.Count);
        Assert.False(canExecute[2]);
        myViewModel.IsBusy = false;
        Assert.Equal(4, canExecute.Count);
        Assert.True(canExecute[3]);
        myViewModel.MyObject.Active = false;
        Assert.Equal(4, canExecute.Count);
    }
