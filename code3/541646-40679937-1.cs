    [XmlIgnore]
    public Dictionary<string, string> Parameters { get; set; }
    
    [XmlArray("Parameters")]
    [XmlArrayItem("Pair")]
    public KeyValuePairSerializable<string, string>[] ParametersXml
    {
        get { return Parameters?.Select(p => new KeyValuePairSerializable<string, string>(p)).ToArray(); }
        set
        {
            if (value == null)
                Parameters = null;
            else
                Parameters = value.ToDictionary(i => i.Key, i => i.Value);
        }
    }
