        private readonly IUserResolverService userResolverService;
        public ApplicationDbContext(IUserResolverService userResolverService) : base()
        {
            this.userResolverService = userResolverService;
        
            var username = userResolverService.GetCurrentUser();
    ...
