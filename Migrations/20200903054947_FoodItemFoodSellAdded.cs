using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManagement.Migrations
{
    public partial class FoodItemFoodSellAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(nullable: true),
                    FoodType = table.Column<string>(nullable: true),
                    FoodPrice = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<string>(nullable: true),
                    HomeDelivery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "FoodSells",
                columns: table => new
                {
                    SellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(nullable: false),
                    WhoOrdered = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateOfOrder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSells", x => x.SellId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodSells");
        }
    }
}
