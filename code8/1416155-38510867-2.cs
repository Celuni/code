    public static class LoggerExtensions
    {
    	/// <summary>
    	/// Logs a message with an exception as Fatal.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Fatal(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Fatal, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message with an exception as Fatal.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Fatal(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Fatal(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Error.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Error(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Error, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message with an exception as Error.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Error(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Error(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Info.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Info(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Info, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message with an exception as Info.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Info(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Info(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Warn.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Warn(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Warn, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message with an exception as Warn.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Warn(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Warn(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Debug.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Debug(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Debug, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message as Debug.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Debug(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Debug(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Trace, the second lowest level.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Trace(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Trace, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message as Trace, the second lowest level.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Trace(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Trace(null, format, args);
    	}
    
    	/// <summary>
    	/// Logs a message with an exception as Verbose, the lowest level.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="exception">The related <see cref="Exception"/> for the message</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Verbose(this ILogger logger, Exception exception, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var formattedMessage = Format(format, args);
    		logger.Write(LogLevel.Verbose, formattedMessage, exception);
    	}
    	/// <summary>
    	/// Logs a message as Verbose, the lowest level.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="format">The message as a string format</param>
    	/// <param name="args">The arguments for the message</param>
    	//[StringFormatMethod("format")]
    	public static void Verbose(this ILogger logger, string format, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		logger.Verbose(null, format, args);
    	}
    
    	private static string Format(string format, params object[] args)
    	{
    		if (args == null || args.Length == 0)
    			return format;
    		return string.Format(CultureInfo.CurrentCulture, format, args);
    	}
    
    	/// <summary>
    	/// Logs the entry to a method as a string like "MyType.MyMethod(1, ABC)". 
    	/// Ensure the method being logged is not in-lined by the compiler/jitter with the
    	/// [MethodImpl(MethodImplOptions.NoInlining)] attribute.
    	/// </summary>
    	/// <param name="logger">The instance of a logger to log with</param>
    	/// <param name="args">The arguments passed to the method</param>
    	/// <remarks>
    	/// The <see cref="MethodEntry"/> logging method is useful for logging that a method has 
    	/// been entered and also capturing the arguments of the method in the log.
    	/// <example>
    	/// In this example we log a method entry and the arguments.
    	/// <code>
    	/// <![CDATA[
    	/// [MethodImpl(MethodImplOptions.NoInlining)]
    	/// public void MyLoggedMethod(string s, DateTime dateTime)
    	/// {
    	///     _logger.MethodEntry(s, dateTime);
    	///     //Method body goes here...
    	/// }
    	/// 
    	/// ]]>
    	/// </code>
    	/// The output may look something like this
    	/// 2012-01-31 12:00 [UI] DEBUG MyLoggedType.MyLoggedMethod(A, 31/12/2001 13:45:27)
    	/// </example>
    	/// </remarks>
    	public static void MethodEntry(this ILogger logger, params object[] args)
    	{
    		if (logger == null) throw new ArgumentNullException("logger");
    		var stackTrace = new StackTrace();
    		var method = stackTrace.GetFrame(1).GetMethod();
    		var type = method.DeclaringType;
    		var typeName = string.Empty;
    		if (type != null) typeName = type.Name;
    		string parenth = "()";
    		var parameterDefinitions = method.GetParameters();
    		if (parameterDefinitions.Length > 0)
    		{
    			if (args == null || args.Length == 0)
    			{
    				parenth = "(...)";
    			}
    			else
    			{
    				var values = string.Join(", ", args);
    				parenth = string.Format(CultureInfo.CurrentCulture, "({0})", values);
    			}
    		}
    
    		logger.Debug("{0}.{1}{2}", typeName, method.Name, parenth);
    	}
    
    	public static IObservable<T> Log<T>(this IObservable<T> source, ILogger logger, string name)
    	{
    		return Observable.Using(
    			() => logger.Time(name),
    			timer => Observable.Create<T>(
    				o =>
    				{
    					logger.Trace("{0}.Subscribe()", name);
    					var subscription = source
    						.Do(
    							i => logger.Trace("{0}.OnNext({1})", name, i),
    							ex => logger.Trace("{0}.OnError({1})", name, ex),
    							() => logger.Trace("{0}.OnCompleted()", name))
    						.Subscribe(o);
    					var disposal = Disposable.Create(() => logger.Trace("{0}.Dispose()", name));
    					return new CompositeDisposable(subscription, disposal);
    				})
    			);
    	}
    
    	public static IDisposable Time(this ILogger logger, string name)
    	{
    		return new Timer(logger, name);
    	}
    
    	private sealed class Timer : IDisposable
    	{
    		private readonly ILogger _logger;
    		private readonly string _name;
    		private readonly Stopwatch _stopwatch;
    
    		public Timer(ILogger logger, string name)
    		{
    			_logger = logger;
    			_name = name;
    			_stopwatch = Stopwatch.StartNew();
    		}
    
    		public void Dispose()
    		{
    			_stopwatch.Stop();
    			_logger.Debug("{0} took {1}", _name, _stopwatch.Elapsed);
    		}
    	}
    }
