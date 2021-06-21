using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.RepositoryInterfaces;
using RestaurantReservation.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ResturantReservationDBContext _context;
        IDbContextTransaction dbContextTransaction = null;
        public UnitOfWork(ResturantReservationDBContext context)
        {
            _context = context;
        }
        public Task<int> Complete()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task StartTransactionScope()
        {
            dbContextTransaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
        }



        public async Task TransactionScopeComplete()
        {
            if (dbContextTransaction != null)
            {
                await dbContextTransaction.CommitAsync();
                await _context.SaveChangesAsync();
            }
        }

        public async Task TransactionScopeDispose()
        {
            if (dbContextTransaction != null)
            {
                await dbContextTransaction.DisposeAsync();
                await _context.DisposeAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
