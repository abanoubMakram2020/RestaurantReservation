using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;
using System.Linq;

namespace CleanArch.Application.AutoMapper
{
    public class UserToUserRegistrationDTOProfile : Profile
    {
        public UserToUserRegistrationDTOProfile()
        {
            CreateMap<User, UserRegistrationDTO>()
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                  .ReverseMap();
        }
       
    }
}
