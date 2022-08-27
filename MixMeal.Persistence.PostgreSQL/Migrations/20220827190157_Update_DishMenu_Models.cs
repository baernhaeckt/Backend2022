using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MixMeal.Persistence.PostgreSQL.Migrations
{
    public partial class Update_DishMenu_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishName",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Ingredients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrates",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Calories = table.Column<double>(type: "double precision", nullable: false),
                    Proteins = table.Column<double>(type: "double precision", nullable: false),
                    Carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    Fat = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishId",
                table: "Ingredients",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Menu_MenuId",
                table: "Dishes",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Menu_MenuId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "DishName",
                table: "Ingredients",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishName",
                table: "Ingredients",
                column: "DishName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishName",
                table: "Ingredients",
                column: "DishName",
                principalTable: "Dishes",
                principalColumn: "Name");
        }
    }
}
