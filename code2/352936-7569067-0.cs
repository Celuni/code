    method1(Func<object[],string> delegate1,Func<object[], object> delegate2,params Object[] parameters)
    {
    
    // There is lot of other code, I haven't put here. To make it clear.
    
        string key = delegate1.DynamicInvoke(parameters);
    
        object instance = delegate2.DynamicInvoke(parameters); 
    // Getting errors here, as parameters mismatch. 
    
    }
