    Type genericListType = typeof (List<>);
    // you can add your types here like typeof(MyClass),typeof(MyClass2)
    Type[] genericArguments = {typeof (Record)}; 
    // create your generic type with generic arguments
    Type myGenericType = genericListType.MakeGenericType(genericArguments);
    // and then  you can create your instance
    var realType = Activator.CreateInstance(myGenericType);
