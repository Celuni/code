    [XmlRoot("chart")]
    public class Chart
    {        
        [XmlAttributeAttribute("palette")]
        public string Palette;
    
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<Category> Categories = new List<Category>();
    }
    
    [XmlRoot("category")]
    public class Category
    {
        [XmlAttribute("label")]
        public string Label;
    }
