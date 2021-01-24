    public class CompressibleHttpRequestCreator : IWebRequestCreate
    {
        public CompressibleHttpRequestCreator()
        {
        }
    
        WebRequest IWebRequestCreate.Create(Uri uri)
        {
            HttpWebRequest httpWebRequest =
                Activator.CreateInstance(typeof(HttpWebRequest),
                BindingFlags.CreateInstance | BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance,
                null, new object[] { uri, null }, null) as HttpWebRequest;
    
            if (httpWebRequest == null)
            {
                return null;
            }
    
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip |
                DecompressionMethods.Deflate;
    
            return httpWebRequest;
        }
    }
