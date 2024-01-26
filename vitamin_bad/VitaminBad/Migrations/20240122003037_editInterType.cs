using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitaminBad.Migrations
{
    public partial class editInterType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_InteractionTypeId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionTypeId",
                table: "Interactions",
                column: "InteractionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_InteractionTypeId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionTypeId",
                table: "Interactions",
                column: "InteractionTypeId",
                unique: true,
                filter: "[InteractionTypeId] IS NOT NULL");
        }
    }
}
