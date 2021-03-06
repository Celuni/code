    if (OldMarketRightsIDs.Count > 0)
    {        
        await Data.MK3Model.Database.ExecuteSqlCommandAsync("DELETE FROM TitleMarketRights WHERE ID in (" + string.Join(", ", OldMarketRightsIDs) + ")");
    }
    
    //This code won't execute till the await has finished
    var NewMarketRights = MarketRights.Select(m => new
    {
        Key = m.Key,
        Value = m.Value.Except(CurrentMarketRights[m.Key].Select(c => c.FK_ProductRight).ToList())
    }).ToList();
    
    foreach (var mr in NewMarketRights)
    {
        foreach (var ProdID in mr.Value)
        {
            Data.MK3Model.TitleMarketRights.Add(new TitleMarketRight { FK_MarketID = (mr.Key == 0) ? null : (int?)mr.Key, FK_TitleID = ID, FK_ProductRight = ProdID });
        }
    }
