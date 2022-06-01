using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Api.Migrations
{
    public partial class NewsUpdate005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Users_UserId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Praise_Users_UserId",
                table: "Praise");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Praise",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Praise_UserId",
                table: "Praise",
                newName: "IX_Praise_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comment",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                newName: "IX_Comment_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Collection",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_UserId",
                table: "Collection",
                newName: "IX_Collection_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Users_AppUserId",
                table: "Collection",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_AppUserId",
                table: "Comment",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Praise_Users_AppUserId",
                table: "Praise",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Users_AppUserId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_AppUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Praise_Users_AppUserId",
                table: "Praise");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Praise",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Praise_AppUserId",
                table: "Praise",
                newName: "IX_Praise_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Comment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AppUserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Collection",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_AppUserId",
                table: "Collection",
                newName: "IX_Collection_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Users_UserId",
                table: "Collection",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Praise_Users_UserId",
                table: "Praise",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
