    public ICollection<MyRowType> RunCommand(Func<IQueryable<MyRowType>,IQueryable<MyRowType>> func)
    {
        using (var db = new MyDbContext())
        {
            IQueryable<MyRowType> q = db.MyRowType
                .Include(r => r.RelatedTableA)
                .Include(r => r.RelatedTableB)
                .Include(r => r.RelatedTableC);
            var result = func(q);
            return result.List();
        }
    }
