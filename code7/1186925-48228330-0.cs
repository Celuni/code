    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _someFilterParameter;
        public CustomAuthorizeAttribute(string someFilterParameter)
        {
            _someFilterParameter = someFilterParameter;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                // this also makes redirect to a login page work properly
                // context.Result = new UnauthorizedResult();
                return;
            }
			// you can also use registered services
            var someService = context.HttpContext.RequestServices.GetService<ISomeService>();
            
            var isAuthorized = someService.IsUserAuthorized(user.Identity.Name, _someFilterParameter);
            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
