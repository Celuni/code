    var idColumn = DbfFieldDescriptors.GetIntegerField("Id");
    var nameColumn = DbfFieldDescriptors.GetStringField("Name");
    var columns = new List<DbfFieldDescriptor>() { idColumn, nameColumn };
    Func<MyClass, object> mapId = myClass => myClass.Id;
    Func<MyClass, object> mapName = myClass => myClass.Name;
    var mapping = new List<Func<MyClass, object>>() { mapId, mapName };
    List<MyClass> values = new List<MyClass>();
    values.Add(new MyClass() { Id = 1, Name = "name1" });
    DbfFile.Write("fileName", values, mapping, columns, Encoding.ASCII);
