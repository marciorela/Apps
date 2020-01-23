using Microsoft.EntityFrameworkCore.Migrations;

namespace Apps.DataDb.Migrations
{
    public partial class serial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serials",
                table: "Apps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serials",
                table: "Apps");
        }
    }
}
