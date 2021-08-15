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
    public interface IAccountService
    {
        Task<ResponseResultDto<string>> Register(BaseRequestDto<UserRegistrationDTO> user);
        Task<ResponseResultDto<TokenDTO>> Login(BaseRequestDto<UserDTO> user);
        Task<ResponseResultDto<bool>> Verification(BaseRequestDto<string> token);
        Task<ResponseResultDto<string>> ResendEmailVerficationToken(BaseRequestDto<string> email);
        Task<ResponseResultDto<bool>> ForgetPassword(BaseRequestDto<UserRegistrationDTO> user);
    }
}
