    static bool CheckWritePermission(string path, string username, string password)
    {
        using (DirectoryEntry de = new DirectoryEntry(path, username, password))
        {
            de.RefreshCache(new string[] { "allowedAttributesEffective" });
            return de.Properties["allowedAttributesEffective"].Value != null;
        }            
    }
