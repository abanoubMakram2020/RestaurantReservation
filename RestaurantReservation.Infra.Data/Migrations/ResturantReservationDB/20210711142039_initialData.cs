using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Infra.Data.Migrations.ResturantReservationDB
{
    public partial class initialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableNo = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Table_TableNo",
                        column: x => x.TableNo,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodSellUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodType_Unit_FoodSellUnit",
                        column: x => x.FoodSellUnit,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationFoods_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationFoods_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "Id", "No" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, "كيلو", "Killo" },
                    { 2, "طبق", "Dish" },
                    { 3, "طاجن", "Casserole" }
                });

            migrationBuilder.InsertData(
                table: "FoodType",
                columns: new[] { "Id", "FoodNameAr", "FoodNameEn", "FoodSellUnit" },
                values: new object[,]
                {
                    { 1, "لحمة", "meat", 1 },
                    { 2, "فراخ", "chicken", 1 },
                    { 3, "طاجن جمبري", "Shrimp Casserole", 2 },
                    { 4, "طاجن لحمة", "Meat Casserole", 2 },
                    { 5, "سلطة خضرا", "green salad", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodType_FoodSellUnit",
                table: "FoodType",
                column: "FoodSellUnit");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TableNo",
                table: "Reservation",
                column: "TableNo");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationFoods_FoodTypeId",
                table: "ReservationFoods",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationFoods_ReservationId",
                table: "ReservationFoods",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationFoods");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Table");
        }
    }
}
