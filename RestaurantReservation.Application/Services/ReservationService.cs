using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;
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

        public ReservationService(IUnitOfWork unitOfWork,
                                  IReservationRepository reservationRepository,
                                  IReservationFoodsRepository reservationFoodsRepository,
                                  IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
            _reservationFoodsRepository = reservationFoodsRepository;
            _autoMapper = autoMapper;
        }

        public async Task<bool> DeleteReservationById(int Id)
        {
            try
            {
                var reservObj = await _reservationRepository.Get(Id);
                if (reservObj != null)
                {
                    _reservationRepository.Delete(reservObj);
                    await _unitOfWork.Complete();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return false;
        }

        public List<Reservation> GetReservationByDate(DateTime date)
        {
            return _reservationRepository.Get(expression: r => r.ReservationDate.Date == date, "Table,ReservationFoods.FoodType").ToList();

        }

        public ReservationModel FillReservationModel(int Id)
        {
            ReservationModel model = new ReservationModel();
            try
            {
                var reservationObj = _reservationRepository.Get(expression: x => x.Id == Id, includes: "Table,ReservationFoods.FoodType").FirstOrDefault();
                if (reservationObj != null)
                {
                    model= _autoMapper.Map<ReservationModel>(reservationObj);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return model;

        }

        public async Task<bool> SaveReservation(ReservationModel reservationModel)
        {
            var reservationFoods = new List<ReservationFoods>();
            reservationModel.FoodTypes.ForEach(x =>
            {
                reservationFoods.Add(new ReservationFoods
                {
                    FoodTypeId = Convert.ToInt32(x),
                    ReservationId = reservationModel.Id
                });
            });
            Reservation reservationObj = new Reservation();
            reservationObj = _autoMapper.Map<Reservation>(reservationModel);
          
                reservationObj.ReservationFoods = reservationFoods;
         
            {
                try
                {
                    if (reservationModel.Id > 0)
                    {
                        var reservFoodsDB = _reservationFoodsRepository.Get(expression: x => x.ReservationId == reservationModel.Id).ToList();
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
                    return await _unitOfWork.Complete() > 0;
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

        }
    }
}
