using System;
using AllInOne.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Model.DTO.General;

namespace AllInOne.Middleware
{
    public class ApiAuthentication
    {
        private readonly RequestDelegate _next;

        public ApiAuthentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtAuthenticationService authenticateService)
        {
            if (!string.IsNullOrWhiteSpace(authenticateService
                .CheckTokenValidate(context.Request.Headers["Security-Token"])))
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.Redirect($"{context.Request.Scheme}://{context.Request.Host}/Home/Login");
            }
        }
    }

    public static class ApiAuthenticationExtention
    {
        public static IApplicationBuilder UseApiAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthentication>();
        }
    }
}