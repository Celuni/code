    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Foo>()
            .Property(x => x.Bar)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Bar>(v));                
    
        base.OnModelCreating(modelBuilder);
    }
