using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.API.Custom
{
    public class CustomAuthorize :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers["x-api-key"].Count == 0 ||
                context.HttpContext.Request.Headers["x-api-key"].FirstOrDefault() != "@E@E2r22")
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
