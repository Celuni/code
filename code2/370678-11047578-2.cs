        /// <summary>
        /// A DeepClone method for types that are not serializable.
        /// </summary>
        public static T DeepCloneWithoutSerialization<T>(this T original)
        {
            return original.deepClone(new Dictionary<object, object>());
        }
        static T deepClone<T>(this T original, Dictionary<object, object> copies)
        {
            return (T)original.deepClone(typeof(T), copies);
        }
        /// <summary>
        /// Deep clone an object without using serialisation.
        /// Creates a copy of each field of the object (and recurses) so that we end up with
        /// a copy that doesn't include any reference to the original object.
        /// </summary>
        static object deepClone(this object original, Type t, Dictionary<object, object> copies)
        {
            // Check if object is immutable or copy on update
            if (t.IsValueType || original == null || t == typeof(string) || t == typeof(Guid)) 
                return original;
            // Interfaces aren't much use to us
            if (t.IsInterface) 
                t = original.GetType();
            object tmpResult;
            // Check if the object already has been copied
            if (copies.TryGetValue(original, out tmpResult))
                return tmpResult;
            object result;
            if (!t.IsArray)
            {
                result = Activator.CreateInstance(t);
                copies.Add(original, result);
                // Maybe you need here some more BindingFlags
                foreach (var field in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance))
                {
                    var fieldValue = field.GetValue(original);
                    field.SetValue(result, fieldValue.deepClone(field.FieldType, copies));
                }
            }
            else
            {
                // Handle arrays here
                var originalArray = (Array)original;
                var resultArray = (Array)originalArray.Clone();
                copies.Add(original, resultArray);
                var elementType = t.GetElementType();
                // If the type is not a value type we need to copy each of the elements
                if (!elementType.IsValueType)
                {
                    var lengths = new int[t.GetArrayRank()];
                    var indicies = new int[lengths.Length];
                    // Get lengths from original array
                    for (var i = 0; i < lengths.Length; i++)
                        lengths[i] = resultArray.GetLength(i);
                    var p = lengths.Length - 1;
                    /* Now we need to iterate though each of the ranks
                     * we need to keep it generic to support all array ranks */
                    while (increment(indicies, lengths, p))
                    {
                        var value = resultArray.GetValue(indicies);
                        if (value != null)
                            resultArray.SetValue(value.deepClone(elementType, copies), indicies);
                    }
                }
                result = resultArray;
            }
            return result;
        }
        static bool increment(int[] indicies, int[] lengths, int p)
        {
            if (p > -1)
            {
                indicies[p]++;
                if (indicies[p] < lengths[p])
                    return true;
                if (increment(indicies, lengths, p - 1))
                {
                    indicies[p] = 0;
                    return true;
                }
            }
            return false;
        }
