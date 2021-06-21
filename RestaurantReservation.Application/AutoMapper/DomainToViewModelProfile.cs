using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;
using System.Linq;

namespace CleanArch.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Reservation, ReservationModel>()
                  .ForMember(dest => dest.TableNoId, opt => opt.MapFrom(src => src.Table.Id))
                  .ForMember(dest => dest.TableNo, opt => opt.MapFrom(src => src.Table.No))
                  .ForMember(dest => dest.FoodTypes, opt => opt.MapFrom(src => src.ReservationFoods.Select(x => x.FoodTypeId.ToString()).ToList()));
        }
       
    }
}
