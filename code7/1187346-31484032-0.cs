    using (var context = new BlogContext()) 
    { 
        //YOU NEED TO ADD THIS
        context.Database.Log = Console.Write; 
     
        var blog = context.Blogs.First(b => b.Title == "One Unicorn"); 
     
        blog.Posts.First().Title = "Green Eggs and Ham"; 
     
        blog.Posts.Add(new Post { Title = "I do not like them!" }); 
     
        context.SaveChanges(); 
    }
