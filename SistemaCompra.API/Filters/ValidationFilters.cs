using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace SistemaCompra.API.Filters
{
    public class ValidationFilters : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var msg = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(m => m.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(msg);
            }

        }
    }
}
