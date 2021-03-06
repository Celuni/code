    // The following example will output "T"
    typeOfProperty = property.PropertyType.GetGenericTypeDefinition();
    Type genericDefinition = typeOfProperty.GetGenericTypeDefinition();
    if (genericDefinition == typeof(ICollection<>))
    {
        Type t1 = typeOfProperty.GetGenericArguments()[0];
        Console.WriteLine(t1.ToString());
    }
    // Instead you might need to do something like the following...
    // This example will output the declared type (e.g., "Int32", "String", etc...)
    typeOfProperty = property.GetGetMethod().ReturnType;
    if (typeOfProperty.IsGenericType)
    {
        Type t2 = typeOfProperty.GetGenericArguments()[0];
        Console.WriteLine(t2.ToString());
    }
