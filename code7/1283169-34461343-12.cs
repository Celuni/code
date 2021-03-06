    public class ParentPage<TEntity>
    {
        public virtual void DisplayRecords(GridView gridView)
        {
            gridView.DataSource = this.GetAllData();
            gridView.DataBind();
        }
        protected virtual  DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
                var data = context.Set<TEntity>();
                return MyDataContext.LINQToDataTable(data);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    
        protected void GridView_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            DisplayRecords(e.Item.OwnerTableView);
        }
    }
    public class **tttPage : ParentPage<tttEntity> 
    {
    }
    public class **bbbPage : ParentPage<bbbEntity> 
    {
    }
