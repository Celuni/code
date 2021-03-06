    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    
    public class JSONHelper
    {
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = 
                  new DataContractJsonSerializer(obj.GetType());
            using( MemoryStream ms = new MemoryStream() ) 
            {
                serializer.WriteObject(ms, obj);
                string retVal = Encoding.Default.GetString(ms.ToArray());
                return retVal;
            }
        }
    
        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using( MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)) )
            {
                DataContractJsonSerializer serializer =
                      new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
                return obj;
            }
        }
    }
