using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Model.DTO.General;
using UnitOfWork.Service.Identity;
using Utility;

namespace AllInOne.Middleware
{
    public class VisitorTracker
    {
        private readonly RequestDelegate _next;

        public VisitorTracker(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IVisitor visitorContext)
        {
            try
            {
                var now = DateTime.Now;
                await _next.Invoke(context);

                var visitor = new Model.Entity.Identity.Visitor
                {
                    UserAgent = context.Request.Headers["User-Agent"].ToString(),
                    Ip = context.Connection.RemoteIpAddress.ToString()
                };
                visitor.Browser = HeaderAnalyzer.GetBrowserName(visitor.UserAgent);
                visitor.Platform = HeaderAnalyzer.GetUserPlatform(visitor.UserAgent);
                visitor.Device = HeaderAnalyzer.GetDeviceName(visitor.UserAgent);
                visitor.UrlPath = $"{context.Request.Method}: {context.Request.Protocol} => {context.Request.Scheme}://" +
                                  $"{context.Request.Host}{context.Request.Path}";
                visitor.IsOurUser = context.Session.Get<Model.Entity.Identity.User>("CurrentUser") != null;
                visitor.UserId = !visitor.IsOurUser ? Guid.Empty :
                    context.Session.Get<Model.Entity.Identity.User>("CurrentUser").Id;
                visitor.ExecuteTime = (float)DateTime.Now.Subtract(now).TotalSeconds;
                visitor.StatusCode = context.Response.StatusCode.ToString();
                visitorContext.Insert(visitor);
                visitorContext.Save();
            }
            catch (Exception)
            {
                await _next.Invoke(context);
            }
        }
    }
    public static class VisitorTrackerExtention
    {
        public static IApplicationBuilder UseVisitorTracker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VisitorTracker>();
        }
    }
}
