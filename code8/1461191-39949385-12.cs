	public void DivideMatrixByScalarFixedPoint(string inputFilname, string outputFilename)
	{
    	using (var inFile = new StreamReader(inputFilname))
		using (var outFile = new StreamWriter(outputFilename))
		{
			float d = 0;
			while (!inFile.EndOfStream)
			{
				var c = (char) inFile.Read();
				if (char.IsDigit(c))
				{
					d *= 10;
					d += c - '0';
				}
				else if (c == ' ' || c == '\n')
				{
					d /= 60000; // divide by 10000 to get 4dps; divide by 6 here too
					outFile.Write(d.ToString("0.0000", CultureInfo.InvariantCulture.NumberFormat));
					outFile.Write(c);
					d = 0;
				}
			}
		}
	}
