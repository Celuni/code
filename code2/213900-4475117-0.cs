    public class SafeDirectoryCatalog : ComposablePartCatalog
    {
        private readonly AggregateCatalog _catalog;
        public SafeDirectoryCatalog(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories);
            _catalog = new AggregateCatalog();
            foreach (var file in files)
            {
                try
                {
                    var asmCat = new AssemblyCatalog(file);
                    //Force MEF to load the plugin and figure out if there are any exports
                    // good assemblies will not throw the RTLE exception and can be added to the catalog
                    if (asmCat.Parts.ToList().Count > 0)
                        _catalog.Catalogs.Add(asmCat);
                }
                catch (ReflectionTypeLoadException)
                {
                }
            }
        }
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return _catalog.Parts; }
        }
    }
