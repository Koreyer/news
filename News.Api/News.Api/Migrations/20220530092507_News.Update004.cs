using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Api.Migrations
{
    public partial class NewsUpdate004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_News_NewsId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_News_NewsId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Praise_News_NewsId",
                table: "Praise");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Praise",
                newName: "NewsaId");

            migrationBuilder.RenameIndex(
                name: "IX_Praise_NewsId",
                table: "Praise",
                newName: "IX_Praise_NewsaId");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Comment",
                newName: "NewsaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_NewsId",
                table: "Comment",
                newName: "IX_Comment_NewsaId");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Collection",
                newName: "NewsaId");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_NewsId",
                table: "Collection",
                newName: "IX_Collection_NewsaId");

            migrationBuilder.AddColumn<int>(
                name: "AccessCount",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionCount",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_News_NewsaId",
                table: "Collection",
                column: "NewsaId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_News_NewsaId",
                table: "Comment",
                column: "NewsaId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Praise_News_NewsaId",
                table: "Praise",
                column: "NewsaId",
                principalTable: "News",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_News_NewsaId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_News_NewsaId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Praise_News_NewsaId",
                table: "Praise");

            migrationBuilder.DropColumn(
                name: "AccessCount",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CollectionCount",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "NewsaId",
                table: "Praise",
                newName: "NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Praise_NewsaId",
                table: "Praise",
                newName: "IX_Praise_NewsId");

            migrationBuilder.RenameColumn(
                name: "NewsaId",
                table: "Comment",
                newName: "NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_NewsaId",
                table: "Comment",
                newName: "IX_Comment_NewsId");

            migrationBuilder.RenameColumn(
                name: "NewsaId",
                table: "Collection",
                newName: "NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_NewsaId",
                table: "Collection",
                newName: "IX_Collection_NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_News_NewsId",
                table: "Collection",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_News_NewsId",
                table: "Comment",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Praise_News_NewsId",
                table: "Praise",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
