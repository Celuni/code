    public static class Extension
    {
        public static void Split<T, TKey>(
            this IObservable<T> source, 
            Func<T, TKey> keySelector, 
            Action<IObservable<TKey>> subscribe)
        {
            // maintain a list of Observables, one for each key (TKey)
            var observables = new ConcurrentDictionary<TKey, Subject<TKey>>();
            // function to create a new Subject
            Func<TKey, Subject<TKey>> createSubject = key =>
            {
                Console.WriteLine("Added for " + key);
                var retval = new Subject<TKey>();
                subscribe(retval);
                retval.OnNext(key);
                return retval;
            };
            // function to update an existing Subject
            Func<TKey, Subject<TKey>, Subject<TKey>> updateSubject = (key, existing) =>
            {
                Console.WriteLine("Updated for " + key);
                existing.OnNext(key);
                return existing;
            };
            source.Subscribe(next =>
            {
                var key = keySelector(next);
                observables.AddOrUpdate(key, createSubject, updateSubject);
            });
            // TODO dispose of all subscribers
        }
        // special case: key selector is just the item pass-through
        public static IDisposable Split<T>(
            this IObservable<T> source, 
            Action<IObservable<T>> subscribe)
        {
            return source.Split(item => item, subscribe);
        }
    }
