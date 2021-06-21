using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.ServicesInterfaces
{
    public interface IReservationFoodsService
    {
        List<FoodType> GetReservationFoodsByReservationId(int reservationId);
        void DeleteReservationFoodsList(List<ReservationFoods> lstReservationFoods);
    }
}
