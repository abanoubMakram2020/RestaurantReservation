// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Infra.Data.Context;

namespace RestaurantReservation.Infra.Data.Migrations
{
    [DbContext(typeof(ResturantReservationDBContext))]
    partial class ResturantReservationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantReservation.Domain.Models.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodNameAr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FoodNameEn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FoodSellUnit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodSellUnit");

                    b.ToTable("FoodType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodNameAr = "لحمة",
                            FoodNameEn = "meat",
                            FoodSellUnit = 1
                        },
                        new
                        {
                            Id = 2,
                            FoodNameAr = "فراخ",
                            FoodNameEn = "chicken",
                            FoodSellUnit = 1
                        },
                        new
                        {
                            Id = 3,
                            FoodNameAr = "طاجن جمبري",
                            FoodNameEn = "Shrimp Casserole",
                            FoodSellUnit = 2
                        },
                        new
                        {
                            Id = 4,
                            FoodNameAr = "طاجن لحمة",
                            FoodNameEn = "Meat Casserole",
                            FoodSellUnit = 2
                        },
                        new
                        {
                            Id = 5,
                            FoodNameAr = "سلطة خضرا",
                            FoodNameEn = "green salad",
                            FoodSellUnit = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableNo");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.ReservationFoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationFoods");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            No = 1
                        },
                        new
                        {
                            Id = 2,
                            No = 2
                        },
                        new
                        {
                            Id = 3,
                            No = 3
                        },
                        new
                        {
                            Id = 4,
                            No = 4
                        },
                        new
                        {
                            Id = 5,
                            No = 5
                        },
                        new
                        {
                            Id = 6,
                            No = 6
                        },
                        new
                        {
                            Id = 7,
                            No = 7
                        },
                        new
                        {
                            Id = 8,
                            No = 8
                        },
                        new
                        {
                            Id = 9,
                            No = 9
                        },
                        new
                        {
                            Id = 10,
                            No = 10
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Unit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameAr = "كيلو",
                            NameEn = "Killo"
                        },
                        new
                        {
                            Id = 2,
                            NameAr = "طبق",
                            NameEn = "Dish"
                        },
                        new
                        {
                            Id = 3,
                            NameAr = "طاجن",
                            NameEn = "Casserole"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.FoodType", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Models.Unit", "Unit")
                        .WithMany("FoodTypes")
                        .HasForeignKey("FoodSellUnit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Models.Table", "Table")
                        .WithMany("Reservation")
                        .HasForeignKey("TableNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.ReservationFoods", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Models.FoodType", "FoodType")
                        .WithMany("ReservationFoods")
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Domain.Models.Reservation", "Reservation")
                        .WithMany("ReservationFoods")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodType");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.FoodType", b =>
                {
                    b.Navigation("ReservationFoods");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Reservation", b =>
                {
                    b.Navigation("ReservationFoods");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Table", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Models.Unit", b =>
                {
                    b.Navigation("FoodTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
