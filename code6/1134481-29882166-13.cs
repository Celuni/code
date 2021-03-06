        public ActionResult Index()
        {
            List<PostImageModel> postsWithImages = new List<PostImageModel>();
            var posts = db.Posts.Where(p => p.BlogUserEmail == User.Identity.Name).Include(p => p.BlogUser).Include(p => p.Category);
            foreach (var item in posts) 
            {
                postsWithImages.Add(new PostImageModel()
                {
                    Post = item,
                    Image = Convert.ToBase64String(item.Picture)
                });
                item.Picture = null;
            }
            return View(postsWithImages);
        }
