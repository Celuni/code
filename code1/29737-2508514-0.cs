    public static bool IsNullOrEmpty(string value)
    {
        if (value != null)
        {
            return (value.Length == 0);
        }
        return true;
    }
