    	public static object JSONDeserialize(string jsonText, Type valueType)
	{
		// HTML-decode the string, in case it has been HTML encoded
		jsonText = System.Web.HttpUtility.HtmlDecode(jsonText);
		
	    Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();
	    
	    json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
	    json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
	    json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
	    json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
	    StringReader sr = new StringReader(jsonText);
	    Newtonsoft.Json.JsonTextReader reader = new JsonTextReader(sr);            
	    object result = json.Deserialize(reader, valueType);
	    reader.Close();
	    return result;
	}
