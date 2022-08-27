using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixMeal.Persistence.PostgreSQL.Migrations
{
    public partial class Add_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "Ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    IngredientName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Allergy_Ingredient_IngredientName",
                        column: x => x.IngredientName,
                        principalTable: "Ingredient",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "IngredientTag",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    IngredientName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTag", x => x.Name);
                    table.ForeignKey(
                        name: "FK_IngredientTag_Ingredient_IngredientName",
                        column: x => x.IngredientName,
                        principalTable: "Ingredient",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Roles = table.Column<List<string>>(type: "text[]", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_IngredientName",
                table: "Allergy",
                column: "IngredientName");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTag_IngredientName",
                table: "IngredientTag",
                column: "IngredientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "IngredientTag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Ingredient");
        }
    }
}
