using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Data.Migrations
{
    public partial class ImageByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Recipes");

            migrationBuilder.AddColumn<byte[]>(
                name: "RecipeImage",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeImage",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Recipes",
                nullable: true);
        }
    }
}
