    void Main()
    {
    	string source = "Tomas\tNordstrom\tSweden\tEurope\tWorld";
    	
    	var sw = Stopwatch.StartNew();
    
    	string result = null;
    
    	var n = 100000000;
    	
    	for (var i = 0; i < n; i++)
    	{
    		result = FindBySplitting(source);
    	}
    	
    	sw.Stop();
    	
    	var splittingNsop = (double)sw.ElapsedMilliseconds / n * 1000000.0;
    	Console.WriteLine("Splitting. {0} ns/op",splittingNsop);
    	
    	Console.WriteLine(result);
    	
    	sw.Restart();
    
    	for (var i = 0; i < n; i++)
    	{
    		result = FindByScanning(source);
    	}
    
    	sw.Stop();
    	
    	var scanningNsop = (double)sw.ElapsedMilliseconds / n * 1000000.0;
    	Console.WriteLine("Scanning. {0} ns/op",
    		scanningNsop);
    	
    	Console.WriteLine(result);
    	
    	Console.WriteLine("Scanning over splitting: {0}", splittingNsop / scanningNsop);
    }
    
    string FindBySplitting(string source)
    {
    	return source.Split('\t')[3];
    }
    
    string FindByScanning(string source)
    {
	    int l = source.Length, p = 0, q = 0, c = 0;
	    while (c++ < 4 - 1)
		    while (p < l && source[p++] != '\t')
			    ;
	    for (q = p; q < l && source[q] != '\t'; q++)
		    ;
	    return source.Substring(p, q - p);
    }
