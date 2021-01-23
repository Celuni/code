    public static bool IsReallyAssignableFrom(this Type type, Type otherType)
    {
        if (type.IsAssignableFrom(otherType))
            return true;
        try
        {
            var v = Expression.Variable(otherType);
            var expr = Expression.Convert(v, type);
            return expr.Method == null || expr.Method.Name == "op_Implicit";
        }
        catch(InvalidOperationException ex)
        {
            return false;
        }
    }
