	// Allocate results using collection initializer syntax for the lists and for the dictionaries.
	// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers
	// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
	var results = new List<Dictionary<string, Dictionary<string, JsonParametersData>>>()
	{
		new Dictionary<string, Dictionary<string, JsonParametersData>>()
		{
			{
				"testmodule1",
				new Dictionary<string, JsonParametersData>()
				{
					{
						"name",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option2" },
						}
					},
					{
						"admin",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option2" },
						}
					},
					{
						"path",
						new JsonParametersData
						{
							required = true,
							options = new List<string>() { "option1", "option2" },
						}
					}
				}
			},
		}
	};
				
	var moduleName = "testmodule2";
	var moduleParameters = new [] { "name", "server", "port" };			
	// Now add another result, allocating the dictionary with collection initializer syntax also
	results.Add(new Dictionary<string, Dictionary<string, JsonParametersData>>()
		{
			{
				moduleName,
				// Loop through the parameters and convert them to a dictionary,
				// where the parameter name is the key and the corresponding JsonParametersData is the value
				moduleParameters
					.ToDictionary(n => n,
								  n => new JsonParametersData
								  {
									  required = true, 
									  options = new List<string>() { "option1", "option2" },
								  })
			}
		});
	
	var json = JsonConvert.SerializeObject(results, Formatting.Indented);
