        public Context(DbConnection connection)
            : base(connection, true)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(_ => _.Contacts)
                .WithOptional(_ => _.User)
                .Map(_ => _.MapKey("UserId"));
            modelBuilder.Entity<User>()
                .HasOptional(_ => _.MyPreferredUser)
                .WithMany()
                .Map(_ => _.MapKey("ContactId"));
        }
    }
