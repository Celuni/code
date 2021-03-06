    public class RequiredParametersFilter : ActionFilterAttribute
    {
        // Cache used to store the required parameters for each request based on the
        // request's http method and local path.
        private readonly ConcurrentDictionary<Tuple<HttpMethod, string>, List<string>> _Cache =
            new ConcurrentDictionary<Tuple<HttpMethod, string>, List<string>>();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Get the request's required parameters.
            List<string> requiredParameters = this.GetRequiredParameters(actionContext);     
       
            // If the required parameters are valid then continue with the request.
            // Otherwise, return status code 400.
            if(this.ValidateParameters(actionContext, requiredParameters))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        private bool ValidateParameters(HttpActionContext actionContext, List<string> requiredParameters)
        {
            // If the list of required parameters is null or containst no parameters 
            // then there is nothing to validate.  
            // Return true.
            if (requiredParameters == null || requiredParameters.Count == 0)
            {
                return true;
            }
            // Attempt to find at least one required parameter that is null.
            bool hasNullParameter = 
                actionContext
                .ActionArguments
                .Any(a => requiredParameters.Contains(a.Key) && a.Value == null);
            // If a null required paramter was found then return false.  
            // Otherwise, return true.
            return !hasNullParameter;
        }
        private List<string> GetRequiredParameters(HttpActionContext actionContext)
        {
            // Instantiate a list of strings to store the required parameters.
            List<string> result = null;
            // Instantiate a tuple using the request's http method and the local path.
            // This will be used to add/lookup the required parameters in the cache.
            Tuple<HttpMethod, string> request =
                new Tuple<HttpMethod, string>(
                    actionContext.Request.Method,
                    actionContext.Request.RequestUri.LocalPath);
            // Attempt to find the required parameters in the cache.
            if (!this._Cache.TryGetValue(request, out result))
            {
                // If the required parameters were not found in the cache then get all
                // parameters decorated with the 'RequiredAttribute' from the action context.
                result = 
                    actionContext
                    .ActionDescriptor
                    .GetParameters()
                    .Where(p => p.GetCustomAttributes<RequiredAttribute>().Any())
                    .Select(p => p.ParameterName)
                    .ToList();
                // Add the required parameters to the cache.
                this._Cache.TryAdd(request, result);
            }
            
            // Return the required parameters.
            return result;
        }
    }
