using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.WEB.Migrations
{
    public partial class WonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WonId",
                table: "Games",
                newName: "WonName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WonName",
                table: "Games",
                newName: "WonId");
        }
    }
}
