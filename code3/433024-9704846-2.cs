    [DataContract]
    class Tweeter
    {
        [DataMember]
        public string geo {get;set;}
        [DataMember]
        public User user {get;set;}
    }
    
    [DataContract]
    class User
    {
        [DataMember]
        public string screen_name {get;set;}
    }
    
    class Converter
    {
        public Tweeter ConvertJson(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tweeter));
    
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                return serializer.ReadObject(ms) as Tweeter;
            }
        }
    }
