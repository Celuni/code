    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication53
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string file = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(file);
                XElement maintenance_anomalies = doc.Descendants().Where(x => x.Name.LocalName == "maintenance_anomalies").FirstOrDefault();
            }
        }
    }
