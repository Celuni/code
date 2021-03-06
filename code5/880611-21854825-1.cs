    public static string ToJson<TEnum>()
    {
        var enumType = typeof(TEnum);
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("enumType");
        }
        var names = Enum.GetNames(enumType);
        var values = Enum.GetValues(enumType).OfType<Enum>().Select(Convert.ToInt64);
        var members = names.Zip(values, (k, v) => new { k, v })
            .ToDictionary(p => p.k, p => p.v);
        return JsonConvert.SerializeObject(members);
    }
