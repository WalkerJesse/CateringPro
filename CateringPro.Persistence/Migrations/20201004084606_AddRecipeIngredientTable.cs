using Microsoft.EntityFrameworkCore.Migrations;

namespace CateringPro.Persistence.Migrations
{
    public partial class AddRecipeIngredientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Measurement = table.Column<decimal>(nullable: false),
                    MeasurementType = table.Column<int>(nullable: false),
                    IngredientID = table.Column<long>(nullable: false),
                    RecipeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.RecipeID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_ID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_ID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient");
        }
    }
}
