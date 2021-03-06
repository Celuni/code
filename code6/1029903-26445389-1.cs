    public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query)
       {
          if (typeof(T) == typeof(StructureDivisionEntity))
          {
              return GetAllWithInclude(query);
          }
       }
            
       private static IQueryable<StructureDivisionEntity> GetAllWithInclude<StructureDivisionEntity> (IQueryable<StructureDivisionEntity> query) 
       {
          return query.Include(e => e.Structure)
    			      .Include(e => e.ParentStructureDivision.Structure)
    			      .Include(e => e.Structure.Site.Client);
       }
