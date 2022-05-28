using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Api.Migrations
{
    public partial class NewsUpdate003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Users_UserId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_News_UserId",
                table: "News",
                newName: "IX_News_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Users_AppUserId",
                table: "News",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Users_AppUserId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "News",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_News_AppUserId",
                table: "News",
                newName: "IX_News_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Users_UserId",
                table: "News",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
