    public static MvcHtmlString WelcomeText(this HtmlHelper htmlHelper)
    {
        var text = string.Empty;
        var areaName = htmlHelper.ViewContext.RouteData.DataTokens.Values["area"].ToString();
        
        if (areaName == "Guest")          
        { 
           text = "Hello Guest";
        }
        return new MvcHtmlString(text);
    }
