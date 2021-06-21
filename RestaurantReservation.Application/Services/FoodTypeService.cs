using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Application.Services
{
    public class FoodTypeService :  IFoodTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFoodTypeRepository _foodTypeRepository;

        public FoodTypeService(IUnitOfWork unitOfWork,
                             IFoodTypeRepository foodTypeRepository)
           
        {
            _unitOfWork = unitOfWork;
            _foodTypeRepository = foodTypeRepository;
        }
        public List<FoodType> GetFoodTypeList()
        {
            return _foodTypeRepository.Get().ToList();
        }


    }
}
