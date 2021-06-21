using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.ServicesInterfaces
{
    public interface IFoodTypeService 
    {
        List<FoodType> GetFoodTypeList();
    }
}
