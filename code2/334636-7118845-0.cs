    {
    	public InArgument<string> TestArg {get; set;}
    	
    	public RootActivity(Activity child)
    	{
    		Implementation = () => child;
    	}
    }
