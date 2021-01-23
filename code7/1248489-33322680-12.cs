    public class JsonDerivedTypeConverer<T> : JsonConverter
    {
        public JsonDerivedTypeConverer() { }
        public JsonDerivedTypeConverer(params Type[] types)
        {
            this.DerivedTypes = types;
        }
        readonly HashSet<Type> derivedTypes = new HashSet<Type>();
        public IEnumerable<Type> DerivedTypes
        {
            get
            {
                return derivedTypes.ToArray(); 
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                derivedTypes.Clear();
                if (value != null)
                    derivedTypes.UnionWith(value);
            }
        }
        JsonObjectContract FindContract(JObject obj, JsonSerializer serializer)
        {
            List<JsonObjectContract> bestContracts = new List<JsonObjectContract>();
            foreach (var type in derivedTypes)
            {
                if (type.IsAbstract)
                    continue;
                var contract = serializer.ContractResolver.ResolveContract(type) as JsonObjectContract;
                if (contract == null)
                    continue;
                if (obj.Properties().Select(p => p.Name).Any(n => contract.Properties.GetClosestMatchProperty(n) == null))
                    continue;
                if (bestContracts.Count == 0 || bestContracts[0].Properties.Count > contract.Properties.Count)
                {
                    bestContracts.Clear();
                    bestContracts.Add(contract);
                }
                else if (contract.Properties.Count == bestContracts[0].Properties.Count)
                {
                    bestContracts.Add(contract);
                }
            }
            return bestContracts.Single();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader); // Throws an exception if the current token is not an object.
            var contract = FindContract(obj, serializer);
            if (contract == null)
                throw new JsonSerializationException("no contract found for " + obj.ToString());
            if (existingValue == null || !contract.UnderlyingType.IsAssignableFrom(existingValue.GetType()))
                existingValue = contract.DefaultCreator();
            using (var sr = obj.CreateReader())
            {
                serializer.Populate(sr, existingValue);
            }
            return existingValue;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
