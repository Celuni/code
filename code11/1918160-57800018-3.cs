    public static string GetDescripcion(int IdxTipo,TipoPuntoClaveConst objec)
    {
        var property = object.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && (int)fi.GetRawConstantValue() == IdxTipo)
                .FirstOrDefault();
       if (property == null) return string.Empty;
        var name = property.Name;
        return ResourceHelper.GetTraduccion(ResourceHelper.FICHERO.General, name);
    }
