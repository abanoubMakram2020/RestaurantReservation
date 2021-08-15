using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using SharedKernal.Core.Common;
using SharedKernal.Middlewares.Basees;
using System;
using System.Threading.Tasks;

namespace RestaurantReservation.Presentation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController
    {
        public Presenter _Presenter;
        private readonly IAccountService _accountService;
        public AccountController(Presenter Presenter, IAccountService accountService)
        {
            _Presenter = Presenter;
            _accountService = accountService;

        }
        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Registration(UserRegistrationDTO userRegistrationDTO)
        {
          
            return await _Presenter.Handle(_accountService.Register, new BaseRequestDto<UserRegistrationDTO>
            {
                Data = userRegistrationDTO
            });

        }
        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            return await _Presenter.Handle(_accountService.Login, new BaseRequestDto<UserDTO>
            {
                Data = userDTO
            });

        }

        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Verfication(string token)
        {
            return await _Presenter.Handle(_accountService.Verification, new BaseRequestDto<string>
            {
                Data = token
            });

        }

        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> ForgetPassword(UserRegistrationDTO userRegistrationDTO)
        {
            return await _Presenter.Handle(_accountService.ForgetPassword, new BaseRequestDto<UserRegistrationDTO>
            {
                Data = userRegistrationDTO
            });

        }
    }
}

