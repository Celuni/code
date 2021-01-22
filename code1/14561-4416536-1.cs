        public static class ObjectExtensions{
    
        public static IDictionary<string, object> AddProperty(this object obj, string name, object value){
            var dictionary = obj.PropertiesToDictionary();
            dictionary.Add(name, value);
            return dictionary;
        }
    
    
    
        //helper
        public static IDictionary<string, object> PropertiesToDictionary(this object obj){
            IDictionary<string, object> result = new Dictionary<string, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor property in properties){
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }
    }
