    var pluginStates = new Dictionary<string, IDictionary<string, object>>();
    
    var dictProjectState = jsonSerializer.Deserialize(reader) as Dictionary<string, object>;
    
    foreach(var projectStatePair in dictProjectState)
    {
        string pluginKey = projectStatePair.Key;
        var pluginValues = new Dictionary<string, object>();
        object[] arrayDictHolder = projectStatePair.Value as object[];
        var dictJsonRep = arrayDictHolder[0] as Dictionary<string, object>;
        var dictObjRep =  arrayDictHolder[1] as Dictionary<string, object>;
        foreach(var JsonRepPair in dictJsonRep)
        {
            string jsonRepresentation = JsonRepPair.Value;
            // We know both dictionaries have the same keys, so
            // get the objType for this JsonRepresentation
            object objType = dictObjRep[JsonRepPair.Key];
            // Note, if you're still serializing objType to a string, you'll need
            // to get the actual Type before calling DeserializeObject.
            object value = JsonConvert.DeserializeObject( jsonRepresentation, objType );
            pluginValues.Add( JsonRepPair.Key );
        }
        pluginStates.Add( pluginKey, pluginValues );
    }
