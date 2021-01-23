    public class PropertyCallAdapterProvider<TThis>
    {
        private static readonly Dictionary<string, IPropertyCallAdapter<TThis>> _instances =
            new Dictionary<string,IPropertyCallAdapter<TThis>>();
        public static IPropertyCallAdapter<TThis> GetInstance(string forPropertyName)
        {
            IPropertyCallAdapter<TThis> instance;
            if (!_instances.TryGetValue(forPropertyName, out instance))
            {
                var property = typeof(TThis).GetProperty(
                    forPropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                MethodInfo getMethod;
                Delegate getterInvocation = null;
                if (property != null && (getMethod = property.GetGetMethod(true)) != null)
                {
                    var openGetterType = typeof(Func<,>);
                    var concreteGetterType = openGetterType
                        .MakeGenericType(typeof(TThis), property.PropertyType);
                    getterInvocation =
                        Delegate.CreateDelegate(concreteGetterType, null, getMethod);
                }
                else
                {
                    //throw exception or create a default getterInvocation returning null
                }
                var openAdapterType = typeof(PropertyCallAdapter<,>);
                var concreteAdapterType = openAdapterType
                    .MakeGenericType(typeof(TThis), property.PropertyType);
                instance = Activator
                    .CreateInstance(concreteAdapterType, getterInvocation)
                        as IPropertyCallAdapter<TThis>;
                _instances.Add(forPropertyName, instance);
            }
            return instance;
        }
    }
