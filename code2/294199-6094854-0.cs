    using System.Reflection
    // ...
    Assembly assembly = Assembly.LoadFile(file);
    yourInterface plugin = Activator.CreateInstance(Type.GetType(assembly));
    // ...
    plugin.GetUI(); // or whatever
