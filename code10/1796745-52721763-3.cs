    public async Task<bool> MyMethod(string _type)
    {
        Type type = Type.GetType(_type);
        var tableSet = _context.Set(type);
        var list = await db.ToListAsync();
        // do something
    }
    // pass the full namespace of class
    var result = await MyMethod("Namespace.Models.MyClass")
