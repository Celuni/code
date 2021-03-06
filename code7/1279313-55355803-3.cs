    [EnableQuery()] // Enables clients to modify the query, by using query options such as $filter, $sort, and $page
    public async Task<IHttpActionResult> GetFoos(ODataQueryOptions<Foo> queryOptions)
    {
        using (var context = new FooBarContext())
        {
            return queryOptions.ApplyTo(context.Foos.AsQueryable());
        }
    }
