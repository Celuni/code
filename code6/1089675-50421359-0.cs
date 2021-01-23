cs
using AspNetCore.RouteAnalyzer; // Add
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddRouteAnalyzer(); // Add
    }
### Case1: View route information on browser
Insert code `routes.MapRouteAnalyzer("/routes");` into Startup.cs as follows.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ....
        app.UseMvc(routes =>
        {
            routes.MapRouteAnalyzer("/routes"); // Add
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        });
    }
Then you can access url of `http://..../routes` to view all route informations on your browser. (This url `/routes` can be customized by `MapRouteAnalyzer()`.)
![screenshot](https://raw.githubusercontent.com/kobake/AspNetCore.RouteAnalyzer/master/screenshots/screenshot.png)
### Case2: Print routes on VS output panel
Insert a code block as below into Startup.cs.
    public void Configure(
        IApplicationBuilder app,
        IHostingEnvironment env,
        IApplicationLifetime applicationLifetime, // Add
        IRouteAnalyzer routeAnalyzer // Add
    )
    {
        ...
    
        // Add this block
        applicationLifetime.ApplicationStarted.Register(() =>
        {
            var infos = routeAnalyzer.GetAllRouteInformations();
            Debug.WriteLine("======== ALL ROUTE INFORMATION ========");
            foreach (var info in infos)
            {
                Debug.WriteLine(info.ToString());
            }
            Debug.WriteLine("");
            Debug.WriteLine("");
        });
    }
Then you can view all route informations on VS output panel.
![screenshot](https://raw.githubusercontent.com/kobake/AspNetCore.RouteAnalyzer/master/screenshots/debugprint.png)
