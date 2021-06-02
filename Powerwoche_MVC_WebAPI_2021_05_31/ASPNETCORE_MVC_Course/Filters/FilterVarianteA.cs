using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Filters
{
    public class ActionFilterExample : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }

    public class AsyncActionFilterExample : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
        }
    }

    //If we want to use our filter globally, we need to register it inside the AddControllers() method in the ConfigureServices method:
    //Implementierung in der Startup.cs
    //services.AddControllers(config => 
    //{
    //    config.Filters.Add(new GlobalFilterExample());
    //});

    //But if we want to use our filter as a service type on the Action or Controller level, we need to register it in the same ConfigureServices method but as a service in the IoC container:

    //services.AddScoped<ActionFilterExample>();
    //services.AddScoped<ControllerFilterExample>();


}
