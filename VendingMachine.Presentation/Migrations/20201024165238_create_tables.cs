using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendingMachine.Presentation.Migrations
{
    public partial class create_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CellsRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendingMachineId = table.Column<int>(nullable: false),
                    CellId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellsRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsideBalanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendingMachineId = table.Column<int>(nullable: false),
                    CentCount = table.Column<int>(nullable: false),
                    NickelCount = table.Column<int>(nullable: false),
                    DimeCount = table.Column<int>(nullable: false),
                    QuarterCount = table.Column<int>(nullable: false),
                    DollarCount = table.Column<int>(nullable: false),
                    FiveDollarCount = table.Column<int>(nullable: false),
                    TenDollarCount = table.Column<int>(nullable: false),
                    TwentyDollarCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsideBalanceRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendingMachineId = table.Column<int>(nullable: false),
                    Stret = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Landmark = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellItemRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(maxLength: 20, nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    GrandTotal = table.Column<int>(nullable: false),
                    GrandSellAmount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellItemRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: true),
                    Privilege = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendingMachineRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency = table.Column<int>(nullable: false),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    GrandBalance = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndOfLifeDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachineRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellsRecords");

            migrationBuilder.DropTable(
                name: "InsideBalanceRecords");

            migrationBuilder.DropTable(
                name: "LocationRecords");

            migrationBuilder.DropTable(
                name: "SellItemRecords");

            migrationBuilder.DropTable(
                name: "UserRecords");

            migrationBuilder.DropTable(
                name: "VendingMachineRecords");
        }
    }
}
