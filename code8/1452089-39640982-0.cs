    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(options =>
        {
            options.Filters.Add(typeof(RequireHttpsInProductionAttribute));
        });
    }
