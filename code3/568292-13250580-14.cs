     return fileRawList.Where(file => file.Time >= beginDate)
                        .Where(file => file.Time < endofLoopDate)
                        .OrderBy(file => file.Time)
                        .GroupBy(file => file.Time.Ticks / timeSpan.Ticks,
                                 (k, g) => new OHLC()
                                      {
                                        Open = g.Select(p => p.Bid).DefaultIfEmpty().First(),
                                        High = g.Select(p => p.Bid).DefaultIfEmpty().Max(),
                                        Low = g.Select(p => p.Bid).DefaultIfEmpty().Min(),
                                        Close = g.Select(p => p.Bid).DefaultIfEmpty().Last(),
                                        Time = g.Select(p => p.Time).DefaultIfEmpty().First()
                                              })
                         .ToList();
