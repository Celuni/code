    var xml = XElement.Load("data.xml");
    var something = xml.Element("ObjectName").Value;
    var sb = new StringBuilder(something).AppendLine(",,,");
    foreach (var node in xml.Descendants("SPSecurableObject"))
    {
        var objectName = node.Element("ObjectName").Value;
        var lines = node.Descendants("SPRoleAssignment")
            .Select(elem => string.Join(",", elem.DescendantNodes().OfType<XText>()));
        if (lines.Any())
        {
            foreach (var line in lines)
                sb.Append(objectName).Append(',').AppendLine(line);
        }
        else
        {
            sb.Append(objectName).AppendLine(",,,");
        }
    }
    Console.WriteLine(sb);
