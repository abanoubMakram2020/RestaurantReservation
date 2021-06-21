using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfile:Profile
    {
    //    reservationModel.FoodTypes.ForEach(x =>
    //        {
    //            reservationFoods.Add(new ReservationFoods
    //            {
    //                FoodTypeId = Convert.ToInt32(x),
    //                ReservationId = reservationModel.Id
    //});
    //        });
public ViewModelToDomainProfile()
        {
            CreateMap<ReservationModel, Reservation>()
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
