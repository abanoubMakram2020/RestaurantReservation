using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Infra.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Infra.Data.Context
{
    public class ResturantReservationDBContext : DbContext
    {
        public ResturantReservationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<ReservationFoods> ReservationFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Table>()
            //.HasOne(a => a.Reservation).WithOne(b => b.Table)
            //.HasForeignKey<Reservation>(e => e.TableNo);

            //modelBuilder.Entity<ReservationFoods>().HasKey(rf => new { rf.ReservationId, rf.FoodTypeId });
            #region Start Seed Data
            modelBuilder.StartSeedData();
            #endregion
        }
    }
}
