       public static class Factory<C> where C : IBaseClass, new()
        {
            private static object initialData;
            private static Dictionary<IKey, Triple<EventHandlerTypes, int, WeakReference>> handlers = new Dictionary<IKey, Triple<EventHandlerTypes, int, WeakReference>>();
            private static Dictionary<IKey, object> data = new Dictionary<IKey, object>();
    
            static Factory()
            {
                C newClass = new C();
                newClass.RegisterSharedData(registerSharedData);
            }
    
            public static void Init<IT>(IT initData)
            {
                initialData = initData;
            }
    
            public static Dt[] GetData<Dt>()
            {
                var dataList = from d in data where d.Key.GetKeyType() == typeof(Dt) select d.Value;
    
                return dataList.Cast<Dt>().ToArray();
            }
    
            private static void registerSharedData(IKey key, object value)
            {
                data.Add(key, value);
            }
    
            public static C Create(int? group)
            {
                C newClass = new C();
                newClass.RegisterSharedHandlers(group, registerSharedHandlers);
                // this is a bit bad here since it will call it on all instances
                // it would be better if you can call this from outside after creating all the classes
                Factory<C>.Call(EventHandlerTypes.SetInitialData, null, initialData);
                return newClass;
            }
    
            private static void registerSharedHandlers(IKey subscriber, int? group, EventHandlerTypes type, Action<object, SharedEventArgs> handler)
            {
                handlers.Add(subscriber, new Triple<EventHandlerTypes, int, WeakReference>(type, group ?? -1, new WeakReference(handler)));
            }
    
            public static void Call<N>(EventHandlerTypes type, int? group, N data)
            {
                Call<N>(null, type, group, data);
            }
    
            public static void Call<N>(object sender, EventHandlerTypes type, int? group, N data)
            {
                SharedEventArgs arg = new SharedEventArgs(data);
    
                var invalid = from h in handlers where h.Value.Third.Target == null select h.Key;
    
                // removing expired weak references
                foreach (var inv in invalid.ToList()) handlers.Remove(inv);
    
                // selecting handlers of classes of this group
                var events = from h in handlers where h.Value.First == type && (!@group.HasValue || h.Value.Second == (int)@group) select h.Value.Third;
    
                foreach (var ev in events.ToList())
                {
                    // this converts the weakReference target to the real method and executes it
                    ((Action<object, SharedEventArgs>)ev.Target)(sender, arg);
                }
    
            }
    
        }
