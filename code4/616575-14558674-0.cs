    List<Essay> essays = new List<Essay>();
            essays.Add(new Essay(){ID = 1, Name = "ccccc"});
            essays.Add(new Essay(){ID = 2, Name = "aaaa"});
            essays.Add(new Essay(){ID = 3, Name = "bbbb"});
            essays.Add(new Essay(){ID = 4, Name = "10"});
            essays.Add(new Essay(){ID = 5, Name = "1"});
            essays.Add(new Essay(){ID = 6, Name = "2"});
            essays.Add(new Essay(){ID = 7, Name = "1a"});
            essays.ForEach(q => Replace(q));
            var result = essays.OrderBy(q => q.Name).ToList();
            result.ForEach(q => Revert(q));
