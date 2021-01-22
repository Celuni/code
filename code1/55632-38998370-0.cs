    bool IsSimple(TypeInfo type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() ==     typeof(Nullable<>))
        {
            // nullable type, check if the nested type is simple.
            return IsSimple((type.GetGenericArguments()[0]).GetTypeInfo());
        }
        return type.IsPrimitive
          || type.IsEnum
          || type.Equals(typeof(string))
          || type.Equals(typeof(decimal));
    }
