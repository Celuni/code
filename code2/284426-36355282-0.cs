     string xmlString = System.IO.File.ReadAllText(@"C:\Users\user\Downloads\userDetail.xml");
      static T ConvertXmlStringtoObject<T>(string xmlString)
            {
                T classObject;
    
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(xmlString))
                {
                    classObject = (T)xmlSerializer.Deserialize(stringReader);
                }
                return classObject;
            }
