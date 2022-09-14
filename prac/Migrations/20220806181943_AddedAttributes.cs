using Microsoft.EntityFrameworkCore.Migrations;

namespace ResTask.Migrations
{
    public partial class AddedAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_MenuDishId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuDishId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuDishId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DishName",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Quantity",
                table: "Orders",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Menus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishName",
                table: "Orders",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_DishName",
                table: "Orders",
                column: "DishName",
                principalTable: "Menus",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_DishName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuDishId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuDishId",
                table: "Orders",
                column: "MenuDishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_MenuDishId",
                table: "Orders",
                column: "MenuDishId",
                principalTable: "Menus",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
