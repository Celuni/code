    public class JSONAPIFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new JsonResult
            {
                Data = ((ViewResult)context.Result).ViewData.Model
            };
        }
    }
