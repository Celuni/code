	string range = "2016-10-01T19:38:05.6409410+00:00,2016-11-21T19:38:05.6409410+00:00";
	if(Range<int>.CanConvert(range))
		Console.WriteLine(Range<int>.Parse(range).AsString);
	if(Range<DateTime>.CanConvert(range))
		Console.WriteLine(Range<DateTime>.Parse(range).AsString);
