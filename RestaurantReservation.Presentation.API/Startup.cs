using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Infra.Data.Context;
using RestaurantReservation.Infra.IOC;
using SharedKernal.Middlewares;

namespace RestaurantReservation.Presentation.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.Initialize();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            #region DB Contexts
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(_configuration.GetConnectionString(DatabaseConfiguration.ResturantReservationIdentityDBConnection)));

            //services.AddDbContext<ResturantReservationDBContext>(options =>
            //options.UseSqlServer(DatabaseConfiguration.ResturantReservationDBConnection));
            #endregion

            services.Initialize();
            RegisterServices(services, _configuration);
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseApiVersioning();

            app.Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration _configuration)
        {
            DependencyContainer.RegisterServices(services, _configuration);
            #region Register Controller For Property DI
            //System.Type controllerBaseType = typeof(BaseController);
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType).PropertiesAutowired();
            #endregion
        }
    }
}
