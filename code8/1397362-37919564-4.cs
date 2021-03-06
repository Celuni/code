    public class YourBusinessObjectRequestDto
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        ...
        
        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>()
            {
              { "id", id },
              { "firstName", firstName },
              { "lastName", lastName },
              { "address", address },
              { "postalCode", postalCode },
              { "...", ... }
            };
          
            return dict.Where(pair => pair.Value != null).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
