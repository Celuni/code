    using( IEnumerator e = collection.GetEnumerator() )
    {
        while( e.MoveNext() )
        {
            // do something with the item
            e.Current ...
        }
    }
