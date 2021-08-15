﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SharedKernal.Core.Common.Configuration;
using SharedKernal.Middlewares.Exception;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.Swagger;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedKernal.Middlewares
{
    public static class Engine
    {
        public static IServiceProvider Container { get; set; }
        public static string[] AllowedOrigins { get; set; }

        public static void Initialize(this IConfiguration configuration)
        {
            var _databaseConfiguration = new DatabaseConfiguration();
            configuration.Bind(nameof(DatabaseConfiguration), _databaseConfiguration);

            var _swaggerSettings = new SwaggerSettings();
            configuration.Bind(nameof(SwaggerSettings), _swaggerSettings);

            var _emailSettings = new EmailSettings();
            configuration.Bind(nameof(EmailSettings), _emailSettings);

            var _jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), _jwtSettings);

            IConfigurationSection originsSection = configuration.GetSection("AllowedOrigins");
            AllowedOrigins = originsSection.AsEnumerable().Where(s => s.Value != null).Select(a => a.Value).ToArray();
        }

        public static void Initialize(this IServiceCollection service)
        {
            #region App localization
            service.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedCultures = new System.Collections.Generic.List<CultureInfo> { new CultureInfo("en") };

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? "en" : firstLang;
                    return System.Threading.Tasks.Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            #endregion

            #region Authentication
            service.AddAuthentication(options =>
               {
                   options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       RequireExpirationTime = JwtSettings.RequireExpirationTime,
                       ValidateIssuer = JwtSettings.ValidateIssuer,
                       ValidateAudience = JwtSettings.ValidateAudience,
                       ValidAudience = JwtSettings.ValidAudience,
                       ValidIssuer = JwtSettings.ValidIssuer,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecurityKey))
                   };
               });
            #endregion

            service.AddSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version, description: SwaggerSettings.Description);
            service.AddMemoryCache();
            service.AddHttpClient();
            service.AddHttpContextAccessor();
        }

        public static void Initialize(this IApplicationBuilder app)
        {
            Container = app.ApplicationServices;

            app.UseSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version);
            app.UseMiddleware<ExceptionHandler>();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }

}