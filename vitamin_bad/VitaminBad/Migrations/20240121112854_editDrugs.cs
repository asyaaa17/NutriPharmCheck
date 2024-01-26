using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitaminBad.Migrations
{
    public partial class editDrugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Drugs");

            migrationBuilder.AddColumn<string>(
                name: "Dose",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dose",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "Drugs");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
