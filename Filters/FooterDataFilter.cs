using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LaCroute.Data;
public class FooterDataFilter : IActionFilter
{
    private readonly LaCrouteContext _context;

    public FooterDataFilter(LaCrouteContext context)
    {
        _context = context;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Controller is Controller controller)
        {
            var reviews = _context.Review.ToList();
            controller.ViewData["Reviews"] = reviews;
        }
    }

}