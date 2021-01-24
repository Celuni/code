    public Expression GetMemberExpression(Expression param, string propertyName)
    {
    	if (propertyName.Contains("."))
      	{
       		int index = propertyName.IndexOf(".");
       		var subParam = Expression.Property(param, propertyName.Substring(0, index));
       		return GetMemberExpression(subParam, propertyName.Substring(index + 1));
       	}
            
        return Expression.Property(param, propertyName);
    }
