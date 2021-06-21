using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Application.Services;
using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWork;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;

namespace RestaurantReservation.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
