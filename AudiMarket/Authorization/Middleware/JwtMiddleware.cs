using AudiMarket.Authorization.Handlers.Interfaces;
using AudiMarket.Domain.Services;
using AudiMarket.Security.Settings;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context, IMusicProducerService musicProducerService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var mProducerId = handler.ValidateToken(token);
            if (mProducerId != null)
                context.Items["MusicProducer"] = await musicProducerService.GetById(mProducerId.Value);

            await _next(context);

        }

    }
}
