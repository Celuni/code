    public class MyContext : DbContext
    {
        ...
        public DbSet<Customer> Customers { get;set; }
        ...
    }
