    public partial class About : Page
    {
        private IProductsRepository _productsRepository;
        public About()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            _productsRepository = new ProductsRepository(new VideoGamesDataContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            var products = _productsRepository.FindAll();
            ShowProducts(products);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierID = int.Parse(DropDownList1.SelectedValue);
            var products = _productsRepository.FindBySupplierId(supplierID);
            ShowProducts(products);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int supplierID = int.Parse(DropDownList1.SelectedValue);
            var products = _productsRepository.FindBySupplierId(supplierID);
            if(chkLike.Checked)
            {
                string productName = txtProductName.Text;
                products = products.Where(p => p.ProductName.StartsWith(productName));
            }
            ShowProducts(products);
        }
        public void ShowProducts(IEnumerable<Product> products)
        {
            GridView1.DataSource = Mapper.Map<IEnumerable<ProductViewModel>>(products);
            GridView1.DataBind();
        }
    }
