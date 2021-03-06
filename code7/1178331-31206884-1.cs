    public async Task<List<NightsSoldGraphInfo>> GetNightsSoldGraphData(
                            PrimaryKey userPk, 
                            NightsSoldGraphCriteria criteria)
    {
        using (ADatabase db = new ADatabase(connectionString))
        {
           var entities = await db.SomeTable.Where(x => x.UserKey == userPk)
                                      .ToListAsync();
           return entities;
        }
     }
