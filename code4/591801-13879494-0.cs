    var holderType = bindingContext.ModelMetadata.ContainerType;
    if (holderType != null)
    {
      var propertyType = holderType.GetProperty(bindingContext.ModelName);
      var attributes = propertyType.GetCustomAttributes(true);
      var hasAttribute = attributes
        .Cast<Attribute>()
        .Any(a => a.GetType().IsEquivalentTo(typeof (FutureDateTime)));
      if(hasAttribute) ...
    }
