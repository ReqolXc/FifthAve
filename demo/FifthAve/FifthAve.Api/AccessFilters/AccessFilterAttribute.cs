using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FifthAve.Api.AccessFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = context.HttpContext.User.Identity;

            if(!identity.IsAuthenticated)
                context.Result = new UnauthorizedResult();

            if (!HasAccess())
                context.Result = new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
            
        }

        protected virtual bool HasAccess() => true;
    }
}
