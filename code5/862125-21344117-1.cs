    namespace XmlToCsv
    {
        class Program
        {
            static void GenerateCsvFromXml(string xmlString, string resultFileName)
            {
                XDocument xDoc = XDocument.Parse(xmlString);
    
                var titlesList = new List<string>();
                var masterValuesList = new List<List<string>>();
    
                // Get title row 
                foreach (var element in xDoc.Root.Elements().First().Elements())
                {
                    titlesList.Add(element.Name.LocalName);
                }
    
                // Get the values
                foreach (var element in xDoc.Root.Elements())
                {
                    var valuesList = new List<string>();
                    foreach (var childElement in element.Elements())
                    {
                        valuesList.Add(childElement.Value);
                    }
                    masterValuesList.Add(valuesList);
                }
    
                // Add titles as first row in master values list
                masterValuesList.Insert(0, titlesList);
    
                // Write the file
                using (var fs = new FileStream(resultFileName, FileMode.Create))
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var values in masterValuesList)
                    {
                        string line = string.Empty;
    
                        foreach (var value in values)
                        {
                            line += value;
                            if (titlesList.IndexOf(value) < titlesList.Count - 1)
                            {
                                line += ",";
                            }
                        }
    
                        sw.WriteLine(line);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                String xmlString = @"<ArrayOfDealer xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
                    <Dealer>
                        <Cmf>76066699</Cmf>
                        <DealerNumber/>
                        <DealershipName>BROWARD MOTORSPORTS - WPB</DealershipName>
                    </Dealer>
                    <Dealer>
                        <Cmf>76071027</Cmf>
                        <DealerNumber/>
                        <DealershipName>BROWARD MOTORSPORTS OF FT LAUDERDALE LLC</DealershipName>
                    </Dealer>
                    <Dealer>
                        <Cmf>76014750</Cmf>
                        <DealerNumber/>
                        <DealershipName>Jet Ski of Miami</DealershipName>
                    </Dealer>
                    <Dealer>
                        <Cmf>76066987</Cmf>
                        <DealerNumber/>
                        <DealershipName>BROWARD MOTORSPORTS - Davie</DealershipName>
                    </Dealer>
                </ArrayOfDealer>";
    
                String xmlString2 = @"<ArrayOfUnicorn xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
                    <Unicorn>
                        <UnicornColor>Red</UnicornColor>
                        <Cmf>76066699</Cmf>
                        <UnicornNumber/>
                        <UnicornshipName>BROWARD MOTORSPORTS - WPB</UnicornshipName>
                    </Unicorn>
                    <Unicorn>
                        <UnicornColor>Red</UnicornColor>
                        <Cmf>76071027</Cmf>
                        <UnicornNumber/>
                        <UnicornshipName>BROWARD MOTORSPORTS OF FT LAUDERDALE LLC</UnicornshipName>
                    </Unicorn>
                    <Unicorn>
                        <UnicornColor>Red</UnicornColor>
                        <Cmf>76014750</Cmf>
                        <UnicornNumber/>
                        <UnicornshipName>Jet Ski of Miami</UnicornshipName>
                    </Unicorn>
                    <Unicorn>
                        <UnicornColor>Red</UnicornColor>
                        <Cmf>76066987</Cmf>
                        <UnicornNumber/>
                        <UnicornshipName>BROWARD MOTORSPORTS - Davie</UnicornshipName>
                    </Unicorn>
                </ArrayOfUnicorn>";
    
                
                GenerateCsvFromXml(xmlString, "Dealer.csv");
                GenerateCsvFromXml(xmlString2, "Unicorn.csv");
            }
        }
    }
