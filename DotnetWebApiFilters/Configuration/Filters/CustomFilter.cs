using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetWebApiFilters.Configuration.Filters;

public class CustomFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Action is executing");
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Action is executed");
    }

}
