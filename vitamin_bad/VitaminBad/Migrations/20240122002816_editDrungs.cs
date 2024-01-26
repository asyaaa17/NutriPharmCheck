using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitaminBad.Migrations
{
    public partial class editDrungs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_DrugsId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_DrugsId",
                table: "Interactions",
                column: "DrugsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interactions_DrugsId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_DrugsId",
                table: "Interactions",
                column: "DrugsId",
                unique: true,
                filter: "[DrugsId] IS NOT NULL");
        }
    }
}
