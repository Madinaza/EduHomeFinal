using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalBackEndEduHome.Migrations
{
    public partial class eventagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailImage",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailImage",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Events");
        }
    }
}
