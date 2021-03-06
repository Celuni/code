    public static Task<T> DeserializeObjectAsync<T>(string xml)
    {
        return Task.Run(() => {
            using (StringReader reader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(reader))
                {
                    DataContractSerializer serializer =
                        new DataContractSerializer(typeof(T));
                    T theObject = (T)serializer.ReadObject(xmlReader);
                    return theObject;
                }
            }
        });
    }
