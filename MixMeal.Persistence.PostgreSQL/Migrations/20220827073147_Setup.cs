using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixMeal.Persistence.PostgreSQL.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    DishType = table.Column<int>(type: "integer", nullable: false),
                    DishSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<double>(type: "double precision", nullable: false),
                    Carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    Fat = table.Column<double>(type: "double precision", nullable: false),
                    Premium = table.Column<bool>(type: "boolean", nullable: false),
                    ValidDishTypes = table.Column<string>(type: "text", nullable: false),
                    DishName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ingredient_Dishes_DishName",
                        column: x => x.DishName,
                        principalTable: "Dishes",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DishName",
                table: "Ingredient",
                column: "DishName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Dishes");
        }
    }
}
