using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Api.Migrations
{
    public partial class NewsUpdate006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentHistory_Users_UserId",
                table: "CommentHistory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CommentHistory",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentHistory_UserId",
                table: "CommentHistory",
                newName: "IX_CommentHistory_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentHistory_Users_AppUserId",
                table: "CommentHistory",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentHistory_Users_AppUserId",
                table: "CommentHistory");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "CommentHistory",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentHistory_AppUserId",
                table: "CommentHistory",
                newName: "IX_CommentHistory_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentHistory_Users_UserId",
                table: "CommentHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
