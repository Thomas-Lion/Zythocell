using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zythocell.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    BeveragType = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Productor = table.Column<string>(nullable: true),
                    Alcohol = table.Column<double>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cellars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(nullable: false),
                    BeverageId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AgeBeverage = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(nullable: false),
                    BeverageId = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropTable(
                name: "Cellars");

            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
