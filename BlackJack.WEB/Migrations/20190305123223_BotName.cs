using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.WEB.Migrations
{
    public partial class BotName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bots");
        }
    }
}
