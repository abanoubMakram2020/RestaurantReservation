using CleanArch.Application.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Application.Services;
using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.Shared;
using RestaurantReservation.Application.UnitOfWork;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Context;
using RestaurantReservation.Infra.Data.Repository;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.Logging;
using SharedKernal.Middlewares.ResourcesReader.Message;
using Microsoft.Extensions.Configuration;
using SharedKernal.Core.Common.Configuration;
using RestaurantReservation.Domain.Models;
using Microsoft.AspNetCore.Identity;
using SharedKernal.Middlewares.JWTSettings;
using Microsoft.AspNetCore.Http;

namespace RestaurantReservation.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            #region DB Contexts
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(DatabaseConfiguration.ResturantReservationIdentityDBConnection));

            services.AddDbContext<ResturantReservationDBContext>(options =>
            options.UseSqlServer(DatabaseConfiguration.ResturantReservationDBConnection));

            #endregion

            AutoMapperConfiguration.RegisterMappings();
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddSingleton<ILogger, Logger>();

            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
            services.AddScoped<IReservationFoodsRepository, ReservationFoodsRepository>();
            services.AddScoped<ITableRepository, TableRepository>();


            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IFoodTypeService, FoodTypeService>();
            services.AddScoped<IReservationFoodsService, ReservationFoodsService>();
            services.AddScoped<ITableService, TableService>();




            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

           
            //services.AddScoped<UserManager<User>>();
            //services.AddSingleton<SignInManager<User>>();
            //services.AddScoped<PasswordHasher<User>>();
            services.AddScoped<IJWTTokenHandler, JWTTokenHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IMessageResourceReader, MessageResourceReader>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<Presenter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
