using AllInOne.Infrastructure;
using AllInOne.Infrastructure.Service;
using DataAccess.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model.DTO.General;
using Newtonsoft.Json;
using System;
using UnitOfWork;
using UnitOfWork.Service.Application;
using UnitOfWork.Service.ClientApi;
using UnitOfWork.Service.Identity;
using Utility;
using Utility.Helpers;

namespace AllInOne
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore);
            services.AddRazorPages().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.Configure<Token>(Configuration.GetSection("Token"));
            GlobalParameter.Connection = Configuration.GetConnectionString("Connection");
            GlobalParameter.ApiBaseAddress = Configuration.GetSection("GlobalParameter")["ApiBaseAddress"];
            GlobalParameter.CdnDomainUrl = Configuration.GetSection("GlobalParameter")["CdnDomainUrl"];
            GlobalParameter.CdnLocalPath = Configuration.GetSection("GlobalParameter")["CdnLocalPath"];
            services.AddDistributedMemoryCache();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(3);
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.SlidingExpiration = true;
            });

            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromMinutes(Configuration.GetSection("Token")["accessExpiration"].ToInt());
                options.IdleTimeout = TimeSpan.FromMinutes(Configuration.GetSection("Token")["accessExpiration"].ToInt());
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(GlobalParameter.Connection));
            //DI Service And Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IImageWriter, ImageWriter>();
            services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();
            //DI Entities
            services.AddScoped<IVisitor, Visitor>();
            services.AddScoped<IRequest, Request>();
            services.AddScoped<IUser, User>();
            services.AddScoped<ISoftware, Software>();
            services.AddLogging(builder => { builder.ClearProviders().AddConsole(); });
            services.AddResponseCaching(op => { op.MaximumBodySize = 2048;});
            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Setup(env);
        }
    }
}