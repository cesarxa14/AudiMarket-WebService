using AudiMarket.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var alloweAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            
            // When Action is decorated with [AllowAnonymous] attribute
            //Then skip authorization process
            if (alloweAnonymous)
                return;

            //Authorization process
            var user = (MusicProducer)context.HttpContext.Items["MusicProducer"];

            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized};
        }
    }
}
