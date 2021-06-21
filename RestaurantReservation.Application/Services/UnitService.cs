using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;

namespace RestaurantReservation.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitOfWork unitOfWork,
                             IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        
    }
}
