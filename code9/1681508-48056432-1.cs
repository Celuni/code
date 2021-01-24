    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
        BuildAppSettingsProvider();
    }
    private void BuildAppSettingsProvider()
    {
        AppSettingsProvider.ConnectionString = Configuration.GetConnectionString("DBContext");
        AppSettingsProvider.IsDevelopment = Configuration["IsDev"];
    }
