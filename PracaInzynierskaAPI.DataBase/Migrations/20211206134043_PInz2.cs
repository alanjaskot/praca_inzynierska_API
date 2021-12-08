using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaInzynierskaAPI.DataBase.Migrations
{
    public partial class PInz2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ForDelete",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverName",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForDelete",
                table: "Books",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
