xDoc.Root.SaveDocument(savePath);
private static void SaveDocument(this XElement doc, string filePath)
{
	foreach (var node in doc.Descendants())
	{
		if (node.Name.NamespaceName == "")
		{
			node.Name = ns + node.Name.LocalName;
		}
	}
	using (var xw = XmlWriter.Create(filePath, new XmlWriterSettings
	{
		//OmitXmlDeclaration = true,
		//Indent = true,
		NamespaceHandling = NamespaceHandling.OmitDuplicates
	}))
	{
		doc.Save(xw);
	}
}	
