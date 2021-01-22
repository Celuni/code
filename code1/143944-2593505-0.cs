    public static IEnumerable<T> SetMyProperty<T>(this IEnumerable<T> sourceList, 
        bool newValue) where T : ClassToUpdate
    {
        Action<T> setProperty = t => t.PropertyToUpdate = newValue;
    
        foreach(var t in sourceList)
        {
            if (t.Dispatcher.CheckAccess())
            {
                setProperty(t);
            }
            else
            {
                t.Dispatcher.Invoke(setProperty, new object[] { t });
            }
    
            yield return t;
        }
    }
