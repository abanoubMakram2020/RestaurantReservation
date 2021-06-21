using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.ServicesInterfaces
{
    public interface IReservationService 
    {
        List<Reservation> GetReservationByDate(DateTime date);
        ReservationModel FillReservationModel(int Id);
        Task<bool> DeleteReservationById(int Id);

        Task<bool> SaveReservation(ReservationModel reservationModel);
    }
}
