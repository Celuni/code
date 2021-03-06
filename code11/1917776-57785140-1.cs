public  class ProductsService
{
    AppDbContext _Context;
    public ProductsService(AppDbContext dbContext)
    {
        _Context = dbContext;
    }
    public Product GetProduct(int id)
    {
        return _Context.Products.Include(p=>p.Category).Where(pro =>pro.Id == id).SingleOrDefault();
    }
    public void UpdateProduct(Product product)
    {
        _Context.Products.AddOrUpdate<Product>(product);
        _Context.SaveChanges();
    }
}
