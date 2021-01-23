    public class RemoveResponseHeadersMiddleware
    {
        readonly IEnumerable<string> _headersToRemove;
        readonly RequestDelegate _next;
        readonly ILoggerFactory _loggerFactory;
        /// <summary>
        /// Create an instance of <see cref="RemoveResponseHeadersMiddleware"/>
        /// </summary>
        /// <param name="next">the next <see cref="RequestDelegate"/> to call in the pipeline</param>
        /// <param name="optionsAccessor">the accessor to <see cref="CommaSeparatedListOptions"/> where headers to remove are configured</param>
        /// <param name="loggerFactory">the logger factory to create logger</param>
        public RemoveResponseHeadersMiddleware(RequestDelegate next, IOptions<CommaSeparatedListOptions> optionsAccessor, ILoggerFactory loggerFactory)
        {
            if (next == null)
                throw new ArgumentNullException("next");
            if (optionsAccessor == null || optionsAccessor.Options == null || optionsAccessor.Options.List == null)
                throw new ArgumentNullException("optionsAccessor");
            if (loggerFactory == null)
                throw new ArgumentNullException("loggerFactory");
            _next = next;
            _headersToRemove = optionsAccessor.Options.List;
            _loggerFactory = loggerFactory;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(new RemoveHeaderHttpContext(context, _headersToRemove, _loggerFactory));            
        }
    }
