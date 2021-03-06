        var list=context.Batch.GroupBy(x=>new{x.ItemName,x.ItemNo})
                              .Select(x=>x new
                              {
                                      ItemName=x.Key.ItemName,
                                      ItemNo=x.Key.ItemNo,
                                      Group1=x.Where(y=>y.GroupName=="Group1").FirstOrDefault(),
                                      Group2=x.Where(y=>y.GroupName=="Group2").FirstOrDefault(),
                                      Group3=x.Where(y=>y.GroupName=="Group3").FirstOrDefault(), 
                                      Group4=x.Where(y=>y.GroupName=="Group4").FirstOrDefault() 
                               })
                             .Select(x=> new SampleModel{
                                      ItemName=x.Key.ItemName,
                                      ItemNo=x.Key.ItemNo,
                                      Group1=x.Group1==nul?0:x.Group1.ItemQty,
                                      Group2=x.Group2==nul?0:x.Group2.ItemQty,
                                      Group3=x.Group3==nul?0:x.Group3.ItemQty,
                                      Group4=x.Group4==nul?0:x.Group4.ItemQty
                                      
                                }).ToList();
