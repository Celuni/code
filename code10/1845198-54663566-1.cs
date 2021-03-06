    var lines = xdoc.Descendants("LineEntity")
        .Select(line => new Line
        {
            //Your rest of code same here
            Vertices = line.Elements("Vertices").Elements("Point").Select(p => new Point 
            {
                X = (decimal)p.Element("X"),
                Y = (decimal)p.Element("Y"),
            }).ToList()
        }).ToList();
