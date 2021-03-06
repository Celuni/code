    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Data;
    public class MenuModel
    {
        public string MyProperty { get; set; }
        public string MyOtherProperty { get; set; }
    }
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;
        public MenuViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await dbContext...
            var model = new MenuModel 
            {
                MyProperty = data.FirstValue,
                MyOtherProperty = data.OtherValue,
            };
            return View(model);
        }
    }
