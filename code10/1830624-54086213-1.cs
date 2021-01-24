    class MyCustomResolver : DefaultContractResolver
    {
    	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    	{
    		var props = base.CreateProperties(type, memberSerialization);
    		return props.Where(p => p.PropertyName != "Password").ToList();
    	}
    }
