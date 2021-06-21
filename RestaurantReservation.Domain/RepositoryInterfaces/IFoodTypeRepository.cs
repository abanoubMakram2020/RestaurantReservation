﻿using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain.RepositoryInterfaces
{
    public interface IFoodTypeRepository : IGenericRepository<FoodType>
    {
    }
}