    static class AssemblyHelper
    {
        public static bool AssemblyIsInGAC(string assemblyFullName)
        {
            try
            {
                var assembly = Assembly.ReflectionOnlyLoad(assemblyFullName);
                return assembly.FullName == assemblyFullName && // makes "mscorlib, Version=wrong version ..." work properly
                    assembly.GlobalAssemblyCache;
            }
            catch(FileNotFoundException)
            {
                return false;
            }
        }
    }
