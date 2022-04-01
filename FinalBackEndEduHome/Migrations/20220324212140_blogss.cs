using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalBackEndEduHome.Migrations
{
    public partial class blogss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailImage",
                table: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "DetailImage",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailImage",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "DetailImage",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
