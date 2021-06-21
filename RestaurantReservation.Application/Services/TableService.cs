using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Application.Services
{
    public class TableService :  ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;

        public TableService(IUnitOfWork unitOfWork, ITableRepository tableRepository)
        {
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
        }

        public List<Table> GetTableNotReservedToday()
        {
            return _tableRepository.Get(s => !s.Reservation.Where(es => es.TableNo == s.Id
            && es.ReservationDate.Date == DateTime.Now.Date).Any()).ToList();
           
        }
    }
}
