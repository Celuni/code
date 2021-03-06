    public static void Main(string[] args)
            {
                using (var stream = new MemoryStream(File.ReadAllBytes("schema.xsd")))
                {
                    var schema = XmlSchema.Read(XmlReader.Create(stream ), null);
                    var gen = new XmlSampleGenerator(schema, new XmlQualifiedName("rootElement"));
                    gen.WriteXml(XmlWriter.Create(@"c:\temp\autogen.xml"));
                    Console.WriteLine("Autogenerated file is here : c:\temp\autogen.xml");
                }            
            }
