using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;

namespace CleanArch.Application.AutoMapper
{
    public class UserToUserDTOProfile : Profile
    {
        public UserToUserDTOProfile()
        {
            CreateMap<User, UserDTO>()
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();
        }
       
    }
}
