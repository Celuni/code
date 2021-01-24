    public static class HttpResponseExtension
	{
		private static readonly RouteData EmptyRouteData = new RouteData();
		private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();
		public static Task WriteModelAsync<TModel>(this HttpContext context, TModel model)
		{
			var result = new ObjectResult(model)
			{
				DeclaredType = typeof(TModel)
			};
			var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ObjectResult>>();
			var routeData = context.GetRouteData() ?? EmptyRouteData;
			var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);
			return executor.ExecuteAsync(actionContext, result);
		}
	}
