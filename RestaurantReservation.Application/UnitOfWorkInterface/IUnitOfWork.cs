using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        Task StartTransactionScope();
        Task TransactionScopeComplete();
        Task TransactionScopeDispose();
        Task<int> Complete();
    }
}
