    public string GetEnumMemberAttrValue(Type enumType, object enumVal)
    {
          var memInfo = enumType.GetMember(enumVal.ToString());
    	  var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMember>().FirstOrDefault();
    	  if(attr != null)
          {
    	      return attr.Value;
    	  }
    	  
    	  return null;
    }
