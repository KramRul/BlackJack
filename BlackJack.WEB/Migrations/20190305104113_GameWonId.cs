using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.WEB.Migrations
{
    public partial class GameWonId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WonId",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonId",
                table: "Games");
        }
    }
}
