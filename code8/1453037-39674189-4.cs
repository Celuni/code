    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string baseUrl = "http://localhost:54479";
                addfolder(baseUrl, 0);
                Console.ReadLine();
            }
            public static void addfolder(string url, int level)
            {
                XDocument xdoc = XDocument.Load(url);
                XElement root = (XElement)xdoc.FirstNode;
                string folderName = (string)root.Attribute("name");
                url = url + "/" + folderName;
                Console.WriteLine("{0},folder : '{1}'", new string(' ', 5 * level), url);
                // xdoc.Save(Console.Out);
                foreach (XElement element in root.Elements())
                {
                    string type = (string)element.Attribute("type");
                    switch (type)
                    {
                        case "folder":
                            string newUrl = url + (string)element.Attribute("name");
                            addfolder(newUrl, level++);
                            break;
                        default:
                            string filename = url + "/" + (string)element.Attribute("name");
                            Console.WriteLine("{0}   filename : '{1}'", new string(' ', 5 * level), filename);
                            break;
                    }
                }
            }
        }
    }
