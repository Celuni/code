        /// <summary>
        /// Provides a null-safe member accessor that will return either the result of the lambda or the specified default value.
        /// </summary>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="projection">A lambda specifying the value to produce.</param>
        /// <param name="defaultValue">The default value to use if the projection or any parent is null.</param>
        /// <returns>the result of the lambda, or the specified default value if any reference in the lambda is null.</returns>
        public static TOut ValueOrDefault<TIn, TOut>(this TIn input, Func<TIn, TOut> projection, TOut defaultValue)
        {
            try
            {
                var result = projection(input);
                if (result == null) result = defaultValue;
                return result;
            }
            catch (NullReferenceException) //most reference types throw this on a null instance
            {
                return defaultValue;
            }
            catch (InvalidOperationException) //Nullable<T> throws this when accessing Value
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// Provides a null-safe member accessor that will return either the result of the lambda or the default value for the type.
        /// </summary>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="projection">A lambda specifying the value to produce.</param>
        /// <returns>the result of the lambda, or default(TOut) if any reference in the lambda is null.</returns>
        public static TOut ValueOrDefault<TIn, TOut>(this TIn input, Func<TIn, TOut> projection)
        {
            return input.ValueOrDefault(projection, default(TOut));
        }
