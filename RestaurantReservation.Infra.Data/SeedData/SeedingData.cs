using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Infra.Data.SeedData
{
    public static class SeedingData
    {
        public static void StartSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.TablsSeedData();
            modelBuilder.UnitsSeedData();
            modelBuilder.FoodsSeedData();
        }

        #region Seeding data method
        static void UnitsSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                SampleEntityData(id: 1, nameAr: "كيلو", nameEn: "Killo"),
                SampleEntityData(id: 2, nameAr: "طبق", nameEn: "Dish"),
                   SampleEntityData(id: 3, nameAr: "طاجن", nameEn: "Casserole"));
        }
        static Unit SampleEntityData(int id, string nameAr, string nameEn) =>
         new Unit
         {
             Id = id,
             NameAr = nameAr,
             NameEn = nameEn
         };


        static void TablsSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasData(
                SampleEntityData(id: 1, tableNo: 1),
                SampleEntityData(id: 2, tableNo: 2),
                SampleEntityData(id: 3, tableNo: 3),
                SampleEntityData(id: 4, tableNo: 4),
                SampleEntityData(id: 5, tableNo: 5),
                SampleEntityData(id: 6, tableNo: 6),
                SampleEntityData(id: 7, tableNo: 7),
                SampleEntityData(id: 8, tableNo: 8),
                SampleEntityData(id: 9, tableNo: 9),
                SampleEntityData(id: 10, tableNo: 10));
        }

        static Table SampleEntityData(int id, int tableNo) =>
        new Table
        {
            Id = id,
            No = tableNo,
        };



        static void FoodsSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodType>().HasData(
                SampleEntityData(id: 1, foodNameAr: "لحمة", foodNameEn: "meat", unitId: 1),
                 SampleEntityData(id: 2, foodNameAr: "فراخ", foodNameEn: "chicken", unitId: 1),
                  SampleEntityData(id: 3, foodNameAr: "طاجن جمبري", foodNameEn: "Shrimp Casserole", unitId: 2),
                   SampleEntityData(id: 4, foodNameAr: "طاجن لحمة", foodNameEn: "Meat Casserole", unitId: 2),
                    SampleEntityData(id: 5, foodNameAr: "سلطة خضرا", foodNameEn: "green salad", unitId: 3)
              );
        }

        static FoodType SampleEntityData(int id, string foodNameAr, string foodNameEn, int unitId) =>
        new FoodType
        {
            Id = id,
            FoodNameAr = foodNameAr,
            FoodNameEn = foodNameEn,
            FoodSellUnit = unitId
        };
        #endregion
    }
}
