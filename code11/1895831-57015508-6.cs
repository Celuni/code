    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    
    namespace ApiAuthorized.Security
    {
        public class RBACExampleMiddleware
        {
            private readonly RequestDelegate _next;
    
            public RBACExampleMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            private Dictionary<string, Dictionary<string, string[]>> _userRoles = new Dictionary<string, Dictionary<string, string[]>>
            {
                ["rogala"] = new Dictionary<string,string[]> { ["Values"] = new string[] { "Admin", "Reader" } },
                ["notRogala"] = new Dictionary<string, string[]> { ["Values"] = new string[] { "Reader" } },
            };
    
            public async Task InvokeAsync(HttpContext context)
            {
                var user = context.Request.Query["user"];
                if (!string.IsNullOrWhiteSpace(user)
                    && _userRoles.ContainsKey(user))
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user));
                    claims.Add(new Claim(ClaimTypes.Email, $"{user}@someemail.com"));
    
                    foreach (var resource in _userRoles[user])
                    {
                        foreach(var role in resource.Value)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, $"{resource.Key}:{role}".ToUpper()));
                        }
                    }
    
                    context.User = new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
                }
                await _next(context);
            }
        }
    }
