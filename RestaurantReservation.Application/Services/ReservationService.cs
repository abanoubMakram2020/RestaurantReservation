using AutoMapper;
using Microsoft.EntityFrameworkCore;

using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationFoodsRepository _reservationFoodsRepository;
        private readonly IMapper _autoMapper;
        private readonly ILogger _logger;

        public ReservationService(IUnitOfWork unitOfWork,
                                  IReservationRepository reservationRepository,
                                  IReservationFoodsRepository reservationFoodsRepository,
                                  IMapper autoMapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
            _reservationFoodsRepository = reservationFoodsRepository;
            _autoMapper = autoMapper;
            _logger = logger;
        }

        public async Task<ResponseResultDto<bool>> DeleteReservationById(BaseRequestDto<int> Id)
        {
            var reservObj = await _reservationRepository.Get(Id.Data);
            if (reservObj == null)
            {
                _logger.Information("test");
                return ResponseResultDto<bool>.NotFound(false, "not found");
         
            }

            _reservationRepository.Delete(reservObj);
            await _unitOfWork.Complete();
            return ResponseResultDto<bool>.Success(true, "Deleted successfully");
        }

        public async Task<ResponseResultDto<List<Reservation>>> GetReservationByDate(BaseRequestDto<DateTime> date)
        {
            var reservationlst = await _reservationRepository.Get(expression: r => r.ReservationDate.Date == date.Data, "Table,ReservationFoods.FoodType").ToListAsync();
            if (!reservationlst.Any())
                return ResponseResultDto<List<Reservation>>.NotFound(null, "not found");


            return ResponseResultDto<List<Reservation>>.Success(reservationlst, " done");
        }

        public async Task<ResponseResultDto<ReservationModel>> FillReservationModel(BaseRequestDto<int> Id)
        {
            ReservationModel model = new ReservationModel();
            var reservationObj = await _reservationRepository.Get(expression: x => x.Id == Id.Data, includes: "Table,ReservationFoods.FoodType").FirstOrDefaultAsync();
            if (reservationObj == null)
                return ResponseResultDto<ReservationModel>.NotFound(null, "not found");


            model = _autoMapper.Map<ReservationModel>(reservationObj);
            return ResponseResultDto<ReservationModel>.Success(model, " done");
        }


        public async Task<ResponseResultDto<bool>> SaveReservation(BaseRequestDto<ReservationModel> reservationModel)
        {
            var reservationFoods = new List<ReservationFoods>();
            reservationModel.Data.FoodTypes.ForEach(x =>
            {
                reservationFoods.Add(new ReservationFoods
                {
                    FoodTypeId = Convert.ToInt32(x),
                    ReservationId = reservationModel.Data.Id
                });
            });

            Reservation reservationObj = new Reservation();

            reservationObj = _autoMapper.Map<Reservation>(reservationModel.Data);

            reservationObj.ReservationFoods = reservationFoods;

            if (reservationModel.Data.Id > 0)
            {
                var reservFoodsDB = await _reservationFoodsRepository.Get(expression: x => x.ReservationId == reservationModel.Data.Id).ToListAsync();
                if (reservFoodsDB != null)
                {
                    _reservationFoodsRepository.Delete(reservFoodsDB);
                }
                _reservationRepository.Update(reservationObj);
            }
            else
            {
                await _reservationRepository.Add(reservationObj);
            }
            return ResponseResultDto<bool>.Success(await _unitOfWork.Complete() > 0, " done");

        }
    }
}
