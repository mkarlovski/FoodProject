using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Data.Migrations
{
    public partial class AddedDateToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Recipes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
