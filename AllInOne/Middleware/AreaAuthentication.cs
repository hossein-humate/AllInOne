using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Model.DTO.General;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Utility;
using static System.String;

namespace AllInOne.Middleware
{
    public class AreaAuthentication
    {
        private readonly RequestDelegate _next;

        public AreaAuthentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtAuthenticationService authenticateService)
        {
            if (!IsNullOrWhiteSpace(authenticateService
                .CheckTokenValidate(context.Session.GetString("Token"))))
            {
                var currentUser = context.Session.Get<User>("CurrentUser");
                var userPermissions = ApiExtension.PostAsync<IEnumerable<Permission>, RequestParameters>(
                    GlobalParameter.ApiBaseAddress,
                    "/api/User/GetUserAllPermissions", new RequestParameters
                    {
                        Param1 = currentUser.Id,
                        Param2 = currentUser.SoftwareId,
                    },
                    context.Session.GetString("Token")).Result;
                if (userPermissions.All(p => !string.Equals(p.Action, context.Request.Path.ToString(), StringComparison.CurrentCultureIgnoreCase)))
                    context.Response.Redirect($"{context.Request.Scheme}://" +
                                              $"{context.Request.Host}/Identity/User/Profile");
                await _next.Invoke(context);
            }
            else
            {
                context.Response.Redirect($"{context.Request.Scheme}://{context.Request.Host}/Home/Login");
            }
        }
    }

    public static class AreaAuthenticationExtention
    {
        public static IApplicationBuilder UseAreaAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AreaAuthentication>();
        }
    }
}