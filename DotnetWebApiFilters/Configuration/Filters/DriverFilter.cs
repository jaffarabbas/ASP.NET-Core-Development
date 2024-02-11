using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetWebApiFilters.Configuration.Filters;

public class DriverFilter :Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Action is executing"+context.HttpContext.Request);
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Action is executing"+context.HttpContext.GetRouteData);
    }

}