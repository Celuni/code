    public bool HasFlag(Enum flag)
    {
    	if (!base.GetType().IsEquivalentTo(flag.GetType()))
    	{
    		throw new ArgumentException(Environment.GetResourceString("Argument_EnumTypeDoesNotMatch", new object[]
    		{
    			flag.GetType(),
    			base.GetType()
    		}));
    	}
    	ulong num = Enum.ToUInt64(flag.GetValue());
    	ulong num2 = Enum.ToUInt64(this.GetValue());
    	return (num2 & num) == num;
    }
