    class XmlOrderTemplate {
      [XmlArray("OrderTemplate")]
      [XmlArrayItem("Order")]
      public List<OrderTemplate> Orders {get;set;}
    }
    
    using(var sw = new StreamWriter(fullPath)){
      var serializer = new XmlSerializer(typeof(XmlOrderTemplate));
       serializer.Serialize(sw, new XmlOrderTemplate {Orders = Data});
    }
