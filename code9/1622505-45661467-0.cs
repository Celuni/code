    public ActionResult Sidebar()
    {
        var PostsTop5 = db.Posts.Include(path => path.Author).OrderByDescending(p => p.Date).Take(3);
        return View("Index", PostsTop5.ToList());
    }
