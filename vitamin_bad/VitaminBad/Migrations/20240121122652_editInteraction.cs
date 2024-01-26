using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitaminBad.Migrations
{
    public partial class editInteraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Heabs_HeabsId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_HeabsId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "HeabsId",
                table: "Interactions");

            migrationBuilder.AddColumn<long>(
                name: "IngredientsId",
                table: "Interactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InteractionId",
                table: "Heabs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_IngredientsId",
                table: "Interactions",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heabs_InteractionId",
                table: "Heabs",
                column: "InteractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heabs_Interactions_InteractionId",
                table: "Heabs",
                column: "InteractionId",
                principalTable: "Interactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Ingredients_IngredientsId",
                table: "Interactions",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heabs_Interactions_InteractionId",
                table: "Heabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Ingredients_IngredientsId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_IngredientsId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Heabs_InteractionId",
                table: "Heabs");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "InteractionId",
                table: "Heabs");

            migrationBuilder.AddColumn<long>(
                name: "HeabsId",
                table: "Interactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_HeabsId",
                table: "Interactions",
                column: "HeabsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Heabs_HeabsId",
                table: "Interactions",
                column: "HeabsId",
                principalTable: "Heabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
