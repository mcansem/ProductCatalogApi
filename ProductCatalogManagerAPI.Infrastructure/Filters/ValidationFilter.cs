using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Infrastructure.Filters
{
    /// <summary>
    /// Custom validation filter class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Validation method to run at action execution
        /// </summary>
        /// <param name="context"> current context</param>
        /// <param name="next"> next context</param>
        /// <returns></returns>
        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}