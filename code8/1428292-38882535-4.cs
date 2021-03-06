    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                GetNode((XElement)doc.FirstNode);
            }
            static void GetNode(XElement element)
            {
                // Loop through the XML nodes until the leaf is reached.
                // Add the nodes to the TreeView during the looping process.
                
                List<XElement> children = element.Elements().ToList();
                for (int index = children.Count - 1; index >= 0; index--)
                {
                    XElement child = children[index];
                    if (child.Name.LocalName == "entry")
                    {
                        child.ReplaceWith(new XElement("entry_" + (index + 1).ToString(), child.Elements()));
                    }
                    GetNode(child);
                }
            }
        }
     
    }
