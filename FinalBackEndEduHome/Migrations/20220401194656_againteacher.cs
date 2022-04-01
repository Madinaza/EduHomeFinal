using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalBackEndEduHome.Migrations
{
    public partial class againteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_TeacherId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Communication",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Teachers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Teachers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Teachers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "Teachers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_SkillId",
                table: "TeacherSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TeacherId",
                table: "Contacts",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_TeacherId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "Communication",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Development",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeader",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TeacherId",
                table: "Contacts",
                column: "TeacherId");
        }
    }
}
