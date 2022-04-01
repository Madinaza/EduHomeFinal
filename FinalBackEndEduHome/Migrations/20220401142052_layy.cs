using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalBackEndEduHome.Migrations
{
    public partial class layy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Layout",
                table: "Layout");

            migrationBuilder.RenameTable(
                name: "Layout",
                newName: "Layouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts");

            migrationBuilder.RenameTable(
                name: "Layouts",
                newName: "Layout");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layout",
                table: "Layout",
                column: "Id");
        }
    }
}
