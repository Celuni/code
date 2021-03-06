    static void ShowExtensionMethods(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsClass && !type.IsGenericTypeDefinition
                && type.BaseType == typeof(object)
                && type.GetConstructors().Length == 0)
            {
                foreach (MethodInfo method in type.GetMethods(
                    BindingFlags.Static |
                    BindingFlags.Public | BindingFlags.NonPublic))
                {
                    ParameterInfo[] args;
                    
                    if ((args = method.GetParameters()).Length > 0 &&
                        HasAttribute(method,
                          "System.Runtime.CompilerServices.ExtensionAttribute"))
                    {
                        Console.WriteLine(type.FullName + "." + method.Name);
                        Console.WriteLine("\tthis " + args[0].ParameterType.Name
                            + " " + args[0].Name);
                        for (int i = 1; i < args.Length; i++)
                        {
                            Console.WriteLine("\t" + args[i].ParameterType.Name
                                + " " + args[i].Name);
                        }
                    }
                }
            }
        }
    }
    static bool HasAttribute(MethodInfo method, string fullName)
    {
        foreach(Attribute attrib in method.GetCustomAttributes(false))
        {
            if (attrib.GetType().FullName == fullName) return true;
        }
        return false;
    }
