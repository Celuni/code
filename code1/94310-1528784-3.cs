    public IList CategoryIDs
    {
        get
        {
            return list.Split(',')
                    .ToList<string>()
                    .ConvertAll<int>(new Converter<string, int>(s => int.Parse(s)));
        }
    }
