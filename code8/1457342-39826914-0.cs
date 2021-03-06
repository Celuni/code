    public class SortItem<TEntity>
    {
        public Expression<Func<TEntity, object>> Selector { get; set; }
        public ListSortDirection Direction { get; set; }  
    }
    public static IQueryable<TEntity> MyCustomSortMethod<TEntity>(
        this IQueryable<TEntity> queryable,
        IEnumerable<SortItem<TEntity>> selectors)
    {
        foreach (var selector in selectors)
        {
            IOrderedQueryable<TEntity> ordered = queryable as IOrderedQueryable<TEntity>;
            if (ordered == null)
            {
                if (selector.Direction == ListSortDirection.Ascending)
                    queryable = queryable.OrderBy(selector.Selector);
                else
                    queryable = queryable.OrderByDescending(selector.Selector);
            }
            else
            {
                if (selector.Direction == ListSortDirection.Ascending)
                    queryable = ordered.ThenBy(selector.Selector);
                else
                    queryable = ordered.ThenByDescending(selector.Selector);
            }
        }
        return queryable;
    }
