    public class AssemblyLoader : AssemblyLoadContext
    {
        private string folderPath;
    
        public AssemblyLoader(string folderPath)
        {
            this.folderPath = folderPath;
        }
    
        protected override Assembly Load(AssemblyName assemblyName)
        {
            var deps = DependencyContext.Default;
            var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
            if (res.Count > 0)
            {
                return Assembly.Load(new AssemblyName(res.First().Name));
            }
            else
            {
                var apiApplicationFileInfo = new FileInfo($"{folderPath}{Path.DirectorySeparatorChar}{assemblyName.Name}.dll");
                if (File.Exists(apiApplicationFileInfo.FullName))
                {
                    return this.LoadFromAssemblyPath(apiApplicationFileInfo.FullName);
                }
            }
            return Assembly.Load(assemblyName);
        }
    }
