using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalBackEndEduHome.Migrations
{
    public partial class @base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_Blogs_BlogId",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_Events_EventId",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_AspNetUsers_UserId",
                table: "BaseEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntities");

            migrationBuilder.RenameTable(
                name: "BaseEntities",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntities_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntities_EventId",
                table: "Comments",
                newName: "IX_Comments_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntities_BlogId",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "BaseEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "BaseEntities",
                newName: "IX_BaseEntities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_EventId",
                table: "BaseEntities",
                newName: "IX_BaseEntities_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "BaseEntities",
                newName: "IX_BaseEntities_BlogId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "BaseEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BaseEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_Blogs_BlogId",
                table: "BaseEntities",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_Events_EventId",
                table: "BaseEntities",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_AspNetUsers_UserId",
                table: "BaseEntities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
