    public T Load<T>(string path, IFormatter formatter)
    {
        if(path ==null) throw new NullReferenceException(nameof(path));
        if(formatter == null) throw new NullReferenceException(nameof(formatter));
        T obj = default(T);
        try
        {
            using (var file = File.Open(path, FileMode.Open))
            {
                obj = (T)formatter.Deserialize(file);
            }
        }
        catch(Exception exception)
        {
            // Log the exception
        }
        return obj;   
    }
