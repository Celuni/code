	StringBuilder sb  = new StringBuilder();
	byte[]        buf = new byte[8192];
	HttpWebRequest  request  = (HttpWebRequest)WebRequest.Create("http://www.your-url.com");
	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
	Stream resStream = response.GetResponseStream();
	string tempString = null;
	int    count      = 0;
	do
	{
		count = resStream.Read(buf, 0, buf.Length);
		if (count != 0)
		{
			tempString = Encoding.ASCII.GetString(buf, 0, count);
			sb.Append(tempString);
		}
	}
	while (count > 0);
	Console.WriteLine(sb.ToString());
