using RestaurantReservation.Domain.Models;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Infra.Data.Repository
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        public TableRepository(ResturantReservationDBContext context) : base(context)
        {

        }

        
    }
}
