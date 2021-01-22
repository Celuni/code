    public static void AddRange<T>(this EntityCollection<T> destinationEntityCollection,
                                           EntityCollection<T> sourceEntityCollection) where T : class  
        {
            var array = new T[sourceEntityCollection.Count()];
            sourceEntityCollection.CopyTo(array,0);
         
            foreach (var entity in array)
            {
                destinationEntityCollection.Add(entity);
            }
        }
