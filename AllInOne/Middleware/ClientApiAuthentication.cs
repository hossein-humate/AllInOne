using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UnitOfWork.Service.Application;
using UnitOfWork.Service.ClientApi;
using Utility;

namespace AllInOne.Middleware
{
    public class ClientApiAuthentication
    {
        private readonly RequestDelegate _next;

        public ClientApiAuthentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IRequest request, ISoftware software)
        {
            try
            {
                var now = DateTime.Now;
                var requestModel = new Model.Entity.ClientApi.Request()
                {
                    UserAgent = context.Request.Headers["User-Agent"].ToString(),
                    Ip = context.Connection.RemoteIpAddress.ToString(),
                    RequestPath = context.Request.Path
                };
                if (string.IsNullOrWhiteSpace(context.Request.Headers["ApiKey"].ToString()))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("درخواست ارسال شده، بدون مجوز است.");
                }

                requestModel.ApiKey = context.Request.Headers["ApiKey"].ToString();
                if (string.IsNullOrWhiteSpace(context.Request.Headers["SoftwareId"].ToString()))
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("سیستم شناسه ی شما را دریافت نکرد.");
                }

                requestModel.SoftwareId = context.Request.Headers["SoftwareId"].ToGuid();
                if (software.IsValidApiKey(context.Request.Headers["ApiKey"],
                    context.Request.Headers["SoftwareId"].ToGuid()))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("درخواست ارسال شده، نا معتبر است.");
                }
                requestModel.RespondTime = (float)DateTime.Now.Subtract(now).TotalSeconds;
                requestModel.StatusCode = context.Response.StatusCode.ToString();
                request.Insert(requestModel);
                request.Save();
            }
            catch (Exception)
            {
                await _next.Invoke(context);
            }
        }
    }
    public static class ClientApiAuthenticationExtention
    {
        public static IApplicationBuilder UseClientApiAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientApiAuthentication>();
        }
    }
}
