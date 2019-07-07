﻿using System;
using AutoMapper;
using Data.Context;



using Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            //services.AddMemoryCache();
            //services.AddSingleton<IConfiguration>(configuration);
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddFacebook(options =>
                {
                    options.AppId = "400769287316836";
                    options.AppSecret = "896d529984a688a55b472eba65a967d2";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "996326863156-enla0cmr75m9i74p5ubstj2tqklpmh7a.apps.googleusercontent.com";
                    options.ClientSecret = "Yuj_3Lq5KjJhgQ6tZ2UmuU52";
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/auth/login";
                    options.LogoutPath = "/auth/logout";
                });
        }

        private static void InitMySql(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

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
            //opt => opt.EnableEndpointRouting = true

            services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            //services.AddMvc();
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
                app.UseMvc();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                });
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseDefaultFiles();
            //{controller}.mvc/{action}/{id} - {controller=Home}/{action=Index}/{id?}
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
