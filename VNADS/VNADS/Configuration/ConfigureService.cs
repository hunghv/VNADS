using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;



using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Services.Mappings;
using Swashbuckle.AspNetCore.Swagger;

namespace VNADS.Configuration
{
    public class ConfigureService
    {
        public static void InitServices(IServiceCollection services, IConfiguration configuration)
        {
            InitAutoMapper(services);
            InitSwagger(services);
            InitAuth(services, configuration);
            InitMySql(services, configuration);
        }

        private static void InitAuth(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ConfirmUser",
            //        policy => policy.Requirements.Add(new AuthorizationsRequirement(AuthorizationKeyConstants.AUTH_CONFIRM_USER)));
            //    options.AddPolicy("GetUser",
            //        policy => policy.Requirements.Add(new AuthorizationsRequirement(AuthorizationKeyConstants.AUTH_GET_USER)));
            //    options.AddPolicy("RemoveUser",
            //        policy => policy.Requirements.Add(new AuthorizationsRequirement(AuthorizationKeyConstants.AUTH_DELETE_USER)));
            //    options.AddPolicy("GetListUser",
            //        policy => policy.Requirements.Add(new AuthorizationsRequirement(AuthorizationKeyConstants.AUTH_GETLIST_USER)));
            //});

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddFacebook(options =>
                {
                    options.AppId = "400769287316836";
                    options.AppSecret = "896d529984a688a55b472eba65a967d2";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "238032973710-0lf98j7ij2oe5ka6e7s7jsct261vte3o.apps.googleusercontent.com";
                    options.ClientSecret = "1LOhFHfJRTp5GFsmq5YWbM3O";
                    options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                    options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
                    options.SaveTokens = true;
                    options.Events.OnCreatingTicket = ctx =>
                    {
                        List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();

                        tokens.Add(new AuthenticationToken()
                        {
                            Name = "TicketCreated",
                            Value = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                        });

                        ctx.Properties.StoreTokens(tokens);

                        return Task.CompletedTask;
                    };
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });
        }

        private static void InitMySql(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoffeeRenoContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    mySqlOptionsAction => mySqlOptionsAction.ServerVersion(new Version(), ServerType.MySql)
                ));

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    mySqlOptionsAction => mySqlOptionsAction.ServerVersion(new Version(), ServerType.MySql)
                ));

            services.AddIdentity<UserProfile, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            //services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader();
            //}));
            //services.AddMvc();
            //services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void InitSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });
        }

        public static void InitConfig(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                //});
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            loggerFactory.AddLog4Net(configuration.GetValue<string>("Log4NetConfigFile:Name"));

        }

        private static void InitAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
