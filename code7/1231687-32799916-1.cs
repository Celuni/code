    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var time = new TimeSpan(0,0,0,0);
    		var oneSec = new TimeSpan(0,0,0,1);
    		var wakeywakey = new TimeSpan(0,23,59,59);
    		
    		while (time <= wakeywakey)
    		{
    			Console.WriteLine(time);
    			time += oneSec;
    		}
    	}
    }
