    using (var session = store.OpenSession())
    {          
        var MovieList = session.Query<Movies>()                                    
            .ToList();
        var states = session.Query<Theaters>()
            .Select(x => x.State)
            .ToList()
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());         
        foreach (var movie in MovieList)
        {
            int NumByState = states.ContainsKey(movie.State)
                ? states[movie.State]
                : 0;
            string MovieName = movie.MovieName;
        }
    } 
