﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CateringPro.Infrastructure.Migrations
{
    public partial class AddRecipeIngredientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    MeasurementType = table.Column<int>(nullable: false),
                    IngredientID = table.Column<long>(nullable: false),
                    RecipeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_ID",
                        column: x => x.ID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_ID",
                        column: x => x.ID,
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
