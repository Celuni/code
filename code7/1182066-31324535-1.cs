    var database = GetDatabase(); // not sure what this type is.
    MethodInfo method = database.GetType().GetMethod("CreateTable");
    var assembly = Assembly.GetExecutingAssembly(); // Assume Class1, Class2 etc are here.
    var tables = new string[] { "Class1","Class2" };
    
    for(int i = 0; i < tables.Length; i++)
    {
        MethodInfo generic = method.MakeGenericMethod(assembly.GetType(tables[i]););
        generic.Invoke(database, null);
    }
