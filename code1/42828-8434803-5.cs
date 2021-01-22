    [TestMethod]
    public void TestAddSinglesInOldObsevableCollection()
    {
      int colChangedEvents = 0;
      int propChangedEvents = 0;
      var collection = new ObservableCollection<object>();
      collection.CollectionChanged += (sender, e) => { colChangedEvents++; };
      (collection as INotifyPropertyChanged).PropertyChanged += (sender, e) => { propChangedEvents++; };
      collection.Add(new object());
      collection.Add(new object());
      collection.Add(new object());
      Assert.AreEqual(3, colChangedEvents);
      Assert.AreEqual(6, propChangedEvents);
    }
