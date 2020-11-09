using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Data.Migrations
{
    public partial class ChangedPricetoINT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FullPrice",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Recipes");

            migrationBuilder.AlterColumn<decimal>(
                name: "FullPrice",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
