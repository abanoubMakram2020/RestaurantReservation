using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Application.Services
{
    public class ReservationFoodsService : IReservationFoodsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationFoodsRepository _reservationFoodsRepository;

        public ReservationFoodsService(IUnitOfWork unitOfWork,
                             IReservationFoodsRepository reservationFoodsRepository)
        {
            _unitOfWork = unitOfWork;
            _reservationFoodsRepository = reservationFoodsRepository;
        }

        public void DeleteReservationFoodsList(List<ReservationFoods> lstReservationFoods)
        {
            _reservationFoodsRepository.Delete(lstReservationFoods);
        }

        public List<FoodType> GetReservationFoodsByReservationId(int reservationId)
        {
            return _reservationFoodsRepository.Get(expression: x=>x.ReservationId== reservationId,includes:nameof(ReservationFoods.FoodType)).Select(x=>x.FoodType).ToList();
        }
    }
}
