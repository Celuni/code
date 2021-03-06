	var results = dt.AsEnumerable()
		.GroupBy(x => 
			new
			{
				Main_group = x.Field<string>("Main_group"),
				CstCmpCode = x.Field<string>("CstCmpCode")
			})
		.Select(x=> 
			new
			{
				Main_group = x.Key.Main_group,
				CstCmpCode = x.Key.CstCmpCode,
				Sub_group = x.Select(s => s.Field<string>("Sub_group"))
					
			} );
	JavaScriptSerializer serializer = new JavaScriptSerializer();
	var serializedString = serializer.Serialize(results);
