    string tableName = "myTable";
    string delimeter = " ";
    string line = null;
    using (Stream stream = File.OpenRead("FilePath"))
    using (StreamReader sr = new StreamReader(stream))
    {
        line = sr.ReadLine();
    }
    string fileHeader = line.Replace("\r", string.Empty).Replace("\n", string.Empty);
    string[] fileHeaderSegments = fileHeader.Split(new string[] { delimeter }, StringSplitOptions.None);
    StringBuilder sb = new StringBuilder(string.Format("CREATE TABLE {0} (", tableName));
    for (int i = 0; i < fileHeaderSegments.Length; i++)
    {
        if (i != 0)
        {
            sb.Append(",");
        }
        sb.Append(fileHeaderSegments[i]);
        sb.Append(" varchar(255)");
    }
    sb.Append(");");
    Console.WriteLine(sb.ToString());
    Console.ReadKey();
