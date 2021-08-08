using System;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new {message = "Não Autorizado"}) {StatusCode = 401};
            }
        }
    }
}