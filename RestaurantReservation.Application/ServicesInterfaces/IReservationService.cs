using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;
using SharedKernal.Middlewares.Basees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.ServicesInterfaces
{
    public interface IReservationService 
    {
       Task<ResponseResultDto<List<Reservation>>> GetReservationByDate(BaseRequestDto<DateTime> date);
        Task<ResponseResultDto<ReservationModel>> FillReservationModel(BaseRequestDto<int> Id);
        Task<ResponseResultDto<bool>> DeleteReservationById(BaseRequestDto<int> Id);

        Task<ResponseResultDto<bool>> SaveReservation(BaseRequestDto<ReservationModel> reservationModel);
    }
}
