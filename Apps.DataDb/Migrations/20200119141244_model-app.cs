using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apps.Migrations
{
    public partial class modelapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Versao = table.Column<string>(nullable: true),
                    Plataforma = table.Column<string>(nullable: true),
                    PathExe = table.Column<string>(nullable: false),
                    PathImg = table.Column<string>(nullable: true),
                    ParamSilentInstall = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
