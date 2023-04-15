using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using WebApplication1.Models;

namespace WebApplication1.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car? car = context.ActionArguments["car"] as Car;
            var regex = new Regex("^(Electric|Gas|Diesel|Hybrid)$",
                            RegexOptions.IgnoreCase,
                            TimeSpan.FromSeconds(2));

            if(car is null || !regex.IsMatch(car.type))
            {
                context.ModelState.AddModelError("Type", "Car Is Not Valid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
