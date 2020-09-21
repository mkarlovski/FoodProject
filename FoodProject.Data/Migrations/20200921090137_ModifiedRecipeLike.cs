using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Data.Migrations
{
    public partial class ModifiedRecipeLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RecipeLikes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "RecipeLikes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RecipeLikes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RecipeLikes");
        }
    }
}
