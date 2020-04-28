using System;
using System.Collections.Generic;
using System.IO;
using AllInOne.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Model.DTO.General;

namespace AllInOne.Infrastructure
{
    public static class InitializeConfigurations
    {
        public static void Setup(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.MapWhen(context => context.Request.Path.Value.StartsWith("/img/")
                || context.Request.Path.Value.Contains("/css/")
                || context.Request.Path.Value.StartsWith("/js/")
                || context.Request.Path.Value.Contains("/font/")
                || context.Request.Path.Value.StartsWith("/fonts/")
                , appBuilder => app.UseStaticFiles(new StaticFileOptions()
                {
                    HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
                    OnPrepareResponse = (context) =>
                    {
                        var header = context.Context.Response.GetTypedHeaders();
                        header.CacheControl = new CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromDays(30)
                        };
                    }
                }));
            app.UseResponseCaching();
            app.UseSession();
            app.UseRouting();
            
            app.UseWhen(context => context.Request.Path.ToString().ToLower() != "/"
                 && !context.Request.Path.ToString().ToLower().Contains("/home/")
                 && !context.Request.Path.ToString().ToLower().Contains("/error/")
                 && !context.Request.Path.ToString().ToLower().Contains("/acme-")
                 && !context.Request.Path.ToString().ToLower().Contains("/vblog/")
                 && !context.Request.Path.ToString().ToLower().Contains("/docs/")
                 && !context.Request.Path.ToString().ToLower().Contains("/sitemap.xml")
                 && !context.Request.Path.ToString().ToLower().Contains("/about")
                 && !context.Request.Path.ToString().ToLower().Contains("/contactus")
                 && !context.Request.Path.ToString().ToLower().Contains("/terms")
                 && !context.Request.Path.ToString().ToLower().Contains("/api/v1/")
                 && !context.Request.Path.ToString().ToLower().Contains("/api/")
                 && !context.Request.Path.ToString().ToLower().Contains("/css/")
                 && !context.Request.Path.ToString().ToLower().Contains("/js/")
                 && !context.Request.Path.ToString().ToLower().Contains("/img/")
                 && !context.Request.Path.ToString().ToLower().Contains("/html"),
            appSecondBranch => { appSecondBranch.UseAreaAuthentication(); });

            app.UseWhen(context => context.Request.Path.ToString().ToLower().Contains("/api/")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/user/loginuser")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/v1/")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/visitor/create")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/user/registerandlogin")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/document/getbyidwithimagechildrens")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/document/getalldocumentlistfortreeview")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/article/getallwithgroupandimage")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/article/getwithgroupandimage")
                   && !context.Request.Path.ToString().ToLower().Contains("/api/articlegroup/getallwitharticleandchilds"),
                appSecondBranch => { appSecondBranch.UseApiAuthentication(); });

            app.UseWhen(context => context.Request.Path.ToString().ToLower().Contains("/api/v1/"),
                appSecondBranch => { appSecondBranch.UseClientApiAuthentication(); });

            app.UseWhen(context => !context.Request.Path.ToString().ToLower().Contains("/api/"),
                appSecondBranch => { appSecondBranch.UseVisitorTracker(); });

            app.Use(async (context, next) =>
            {
                //context.Response.Headers.TryAdd("Content-Security-Policy", $"default-src 'self' {context.Request.Scheme}://{context.Request.Host};");
                context.Response.Headers.TryAdd("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.TryAdd("X-Content-Type-Options", "nosniff");
                context.Response.Headers.TryAdd("Referrer-Policy", "strict-origin-when-cross-origin");
                context.Response.Headers.TryAdd("X-Permitted-Cross-Domain-Policies", "none");
                context.Response.Headers.TryAdd("Feature-Policy", "geolocation 'self'");
                context.Response.Headers.TryAdd("Feature-Policy", "geolocation 'self'");
                context.Response.Headers.TryAdd("X-Xss-Protection", "1");
                context.Response.Headers.Remove("X-Powered-By");
                context.Response.Headers.Remove("Server");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("Identity", "Identity",
                    "Identity/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("Application", "Application",
                    "Application/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("TaskManager", "TaskManager",
                    "TaskManager/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("BaseInfo", "BaseInfo",
                    "BaseInfo/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
