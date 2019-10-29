using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogger.Infrastructure.Persistence.Migrations
{
    public partial class AddContentToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "Description");
        }
    }
}
