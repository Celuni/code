    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new FaultExceptionFilterAttribute());
    
            // Other configuration code...
        }
    }
