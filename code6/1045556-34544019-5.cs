     public class DataContext : IdentityDbContext<User>
    {
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            builder.Entity<ConsignorUserMapping>().AddFluentMapping<ConsignorUserMapping>();
            builder.Entity<DealerUserMapping>().AddFluentMapping<DealerUserMapping>();           
            
        }
