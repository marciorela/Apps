using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apps.DataDb.Migrations
{
    public partial class categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Apps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_CategoriaId",
                table: "Apps",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Categorias_CategoriaId",
                table: "Apps",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Categorias_CategoriaId",
                table: "Apps");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Apps_CategoriaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Apps");
        }
    }
}
