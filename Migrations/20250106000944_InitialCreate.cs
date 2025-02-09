using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shedule.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    INN = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsibleCityId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsEnableForDownloadingPayments = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEnable = table.Column<bool>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDeferment = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerName = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerPassword = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerStatus = table.Column<string>(type: "TEXT", nullable: false),
                    IsEnable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentSumm = table.Column<double>(type: "REAL", nullable: false),
                    PaymentText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SaleSumm = table.Column<double>(type: "REAL", nullable: false),
                    SaleName = table.Column<string>(type: "TEXT", nullable: false),
                    SaleCityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerName = table.Column<string>(type: "TEXT", nullable: false),
                    INN = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "PaymentEvents");

            migrationBuilder.DropTable(
                name: "SaleEvents");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
