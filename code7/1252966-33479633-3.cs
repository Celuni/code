    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<ArrayOfFeed xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                          "<XmlItem Name=\"Test\">" +
                            "<Items>" +
                              "<SubItem>" +
                                "<Title>Some Title</Title>" +
                                "<Date>Fri, 30 Oct</Date>" +
                              "</SubItem>" +
                              "<SubItem>" +
                                "<Title>Some Title</Title>" +
                                "<Date>Fri, 30 Oct</Date>" +
                              "</SubItem>" +
                            "</Items>" +
                          "</XmlItem>" +
                        "</ArrayOfFeed>";
                XDocument doc = XDocument.Parse(xml);
                string itemToFind = "Test";
                List<Item> items = doc.Descendants("XmlItem").Where(x => x.Attribute("Name").Value == itemToFind).Descendants("SubItem").Select(y => new Item
                {
                    Title = y.Element("Title").Value,
                    Date = DateTime.ParseExact(y.Element("Date").Value, "ddd, dd MMM", System.Globalization.CultureInfo.InvariantCulture)
                }).ToList();
            }
        }
        public class Item
        {
            public string Title { get; set; }
            public DateTime Date { get; set; }
        }
    }
    ​
