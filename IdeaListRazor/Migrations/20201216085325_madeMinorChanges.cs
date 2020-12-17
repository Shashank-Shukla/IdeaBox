using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class madeMinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Idea");

            migrationBuilder.AddColumn<string>(
                name: "IdeaText",
                table: "Idea",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdeaText",
                table: "Idea");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Idea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
